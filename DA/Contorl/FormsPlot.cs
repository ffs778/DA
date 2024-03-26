using ScottPlot.Control;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

#pragma warning disable IDE1006 // lowercase public properties
#pragma warning disable CS0067 // unused events

namespace ScottPlot
{
    public partial class FormsPlot : UserControl//, IPlotControl
    {
        /// <summary>
        /// This is the plot displayed by the user control.
        /// After modifying it you may need to call Refresh() to request the plot be redrawn on the screen.
        /// </summary>
        public Plot Plot => Backend.Plot;

        /// <summary>
        /// This object can be used to modify advanced behaior and customization of this user control.
        /// </summary>
        public Control.Configuration Configuration { get; }

        /// <summary>
        /// This event is invoked any time the axis limits are modified.
        /// </summary>
        public event EventHandler AxesChanged;

        /// <summary>
        /// This event is invoked any time the plot is right-clicked.
        /// By default it contains DefaultRightClickEvent(), but you can remove this and add your own method.
        /// </summary>
        public event EventHandler RightClicked;

        /// <summary>
        /// This event is invoked any time the plot is left-clicked.
        /// It is typically used to interact with custom plot types.
        /// </summary>
        public event EventHandler LeftClicked;

        /// <summary>
        /// This event is invoked when a <seealso cref="Plottable.IHittable"/> plottable is left-clicked.
        /// </summary>
        public event EventHandler LeftClickedPlottable;

        /// <summary>
        /// This event is invoked after the mouse moves while dragging a draggable plottable.
        /// The object passed is the plottable being dragged.
        /// </summary>
        public event EventHandler PlottableDragged;

        [Obsolete("use 'PlottableDragged' instead", error: true)]
        public event EventHandler MouseDragPlottable;

        /// <summary>
        /// This event is invoked right after a draggable plottable was dropped.
        /// The object passed is the plottable that was just dropped.
        /// </summary>
        public event EventHandler PlottableDropped;

        [Obsolete("use 'PlottableDropped' instead", error: true)]
        public event EventHandler MouseDropPlottable;

        private readonly Control.ControlBackEnd Backend;
        private readonly Dictionary<Cursor, System.Windows.Forms.Cursor> Cursors;

        [Obsolete("Reference 'Plot' instead of 'plt'")]
        public Plot plt => Plot;

        public FormsPlot()
        {
            Backend = new Control.ControlBackEnd(1, 1, "FormsPlot");
            Backend.Resize(Width, Height, useDelayedRendering: false);
            Backend.BitmapChanged += new EventHandler(OnBitmapChanged);
            Backend.BitmapUpdated += new EventHandler(OnBitmapUpdated);
            Backend.CursorChanged += new EventHandler(OnCursorChanged);
            Backend.RightClicked += new EventHandler(OnRightClicked);
            Backend.AxesChanged += new EventHandler(OnAxesChanged);
            Backend.PlottableDragged += new EventHandler(OnPlottableDragged);
            Backend.PlottableDropped += new EventHandler(OnPlottableDropped);
            Configuration = Backend.Configuration;
            Cursors = new Dictionary<Cursor, System.Windows.Forms.Cursor>()
            {
                [ScottPlot.Cursor.Arrow] = System.Windows.Forms.Cursors.Arrow,
                [ScottPlot.Cursor.WE] = System.Windows.Forms.Cursors.SizeWE,
                [ScottPlot.Cursor.NS] = System.Windows.Forms.Cursors.SizeNS,
                [ScottPlot.Cursor.All] = System.Windows.Forms.Cursors.SizeAll,
                [ScottPlot.Cursor.Crosshair] = System.Windows.Forms.Cursors.Cross,
                [ScottPlot.Cursor.Hand] = System.Windows.Forms.Cursors.Hand,
                [ScottPlot.Cursor.Question] = System.Windows.Forms.Cursors.Help,
            };
            InitializeComponent();
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            Plot.Style(figureBackground: System.Drawing.Color.Transparent);
            pictureBox1.MouseWheel += PictureBox1_MouseWheel;
            RightClicked += DefaultRightClickEvent;

            Backend.StartProcessingEvents();
        }

        /// <summary>
        /// Return the mouse position on the plot (in coordinate space) for the latest X and Y coordinates
        /// </summary>
        public (double x, double y) GetMouseCoordinates(int xAxisIndex = 0, int yAxisIndex = 0) => Backend.GetMouseCoordinates(xAxisIndex, yAxisIndex);

        /// <summary>
        /// Return the mouse position (in pixel space) for the last observed mouse position
        /// </summary>
        public (float x, float y) GetMousePixel() => Backend.GetMousePixel();

        /// <summary>
        /// Reset this control by replacing the current plot with a new empty plot
        /// </summary>
        public void Reset()
        {
            Backend.Reset(Width, Height);
            Plot.Style(figureBackground: System.Drawing.Color.Transparent);
        }

        /// <summary>
        /// Reset this control by replacing the current plot with an existing plot通过将当前绘图替换为现有绘图来重置此控件
        /// </summary>
        public void Reset(Plot newPlot)
        {
            Backend.Reset(Width, Height, newPlot);
            Plot.Style(figureBackground: System.Drawing.Color.Transparent);
        }

        /// <summary>
        /// Re-render the plot and update the image displayed by this control.
        /// </summary>
        public override void Refresh()
        {
            Refresh(false, false);      // 执行自定义刷新控件方法
            base.Refresh(); // Forms.Controls的Refresh()方法
        }

        /// <summary>
        /// Re-render the plot and update the image displayed by this control.重新渲染绘图并更新此控件显示的图像
        /// </summary>
        /// <param name="lowQuality">disable anti-aliasing to produce faster (but lower quality) plots禁用抗锯齿以生成更快（但质量较低）的绘图</param>
        /// <param name="skipIfCurrentlyRendering"></param>
        public void Refresh(bool lowQuality = false, bool skipIfCurrentlyRendering = false)
        {
            Backend.WasManuallyRendered = true;
            Backend.Render(lowQuality, skipIfCurrentlyRendering);
        }

        // TODO: mark this obsolete in ScottPlot 5.0 (favor Refresh)
        /// <summary>
        /// Re-render the plot and update the image displayed by this control.
        /// </summary>
        /// <param name="lowQuality">disable anti-aliasing to produce faster (but lower quality) plots</param>
        /// <param name="skipIfCurrentlyRendering"></param>
        public void Render(bool lowQuality = false, bool skipIfCurrentlyRendering = false)
            => Refresh(lowQuality, skipIfCurrentlyRendering);

        /// <summary>
        /// Request the control to refresh the next time it is available.
        /// This method does not block the calling thread.
        /// </summary>
        public void RefreshRequest(RenderType renderType = RenderType.LowQualityThenHighQualityDelayed)
        {
            Backend.WasManuallyRendered = true;
            Backend.RenderRequest(renderType);
        }

        // TODO: mark this obsolete in ScottPlot 5.0 (favor Refresh)
        /// <summary>
        /// Request the control to refresh the next time it is available.
        /// This method does not block the calling thread.
        /// </summary>
        public void RenderRequest(RenderType renderType = RenderType.LowQualityThenHighQualityDelayed) =>
            RefreshRequest(renderType);

        private void FormsPlot_Load(object sender, EventArgs e) { OnSizeChanged(null, null); }
        private void OnBitmapUpdated(object sender, EventArgs e) { pictureBox1.Refresh(); }
        private void OnBitmapChanged(object sender, EventArgs e) { pictureBox1.Image = Backend.GetLatestBitmap(); }
        private void OnCursorChanged(object sender, EventArgs e) => Cursor = Cursors[Backend.Cursor];
        private void OnSizeChanged(object sender, EventArgs e) => Backend.Resize(Width, Height, useDelayedRendering: true);
        private void OnAxesChanged(object sender, EventArgs e) => AxesChanged?.Invoke(this, e);
        private void OnRightClicked(object sender, EventArgs e) => RightClicked?.Invoke(this, e);
        private void OnPlottableDragged(object sender, EventArgs e) => PlottableDragged?.Invoke(sender, e);
        private void OnPlottableDropped(object sender, EventArgs e) => PlottableDropped?.Invoke(sender, e);
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e) { Backend.MouseDown(GetInputState(e)); base.OnMouseDown(e); }
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e) { Backend.MouseUp(GetInputState(e)); base.OnMouseUp(e); }
        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e) { Backend.MouseWheel(GetInputState(e)); base.OnMouseWheel(e); }
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e) { Backend.MouseMove(GetInputState(e)); base.OnMouseMove(e); }
        private void PictureBox1_MouseEnter(object sender, EventArgs e) => base.OnMouseEnter(e);
        private void PictureBox1_MouseLeave(object sender, EventArgs e) => base.OnMouseLeave(e);

        private Control.InputState GetInputState(MouseEventArgs e) =>
            new()
            {
                X = e.X,
                Y = e.Y,
                LeftWasJustPressed = e.Button == MouseButtons.Left,
                RightWasJustPressed = e.Button == MouseButtons.Right,
                MiddleWasJustPressed = e.Button == MouseButtons.Middle,
                ShiftDown = ModifierKeys.HasFlag(Keys.Shift),
                CtrlDown = ModifierKeys.HasFlag(Keys.Control),
                AltDown = ModifierKeys.HasFlag(Keys.Alt),
                WheelScrolledUp = e.Delta > 0,
                WheelScrolledDown = e.Delta < 0,
            };

        public void DefaultRightClickEvent(object sender, EventArgs e)
        {
            DefaultRightClickMenu.Show(System.Windows.Forms.Cursor.Position);
        }
        private void RightClickMenu_Copy_Click(object sender, EventArgs e) => Clipboard.SetImage(Plot.Render());
        private void RightMenuItemClick_AutoAxis(object sender, EventArgs e) { Plot.AxisAuto(); Refresh();}
        private void RightClickMenu_SaveImage_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                FileName = $"图表图片.png",
                Filter = "PNG Files (*.png)|*.png;*.png" +
                         "|JPG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg" +
                         "|BMP Files (*.bmp)|*.bmp;*.bmp" +
                         "|All files (*.*)|*.*"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
                Plot.SaveFig(sfd.FileName);
        }
    }
}
