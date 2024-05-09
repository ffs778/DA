using System;
using System.Collections.Generic;
using System.Drawing;

namespace DA
{
    public class ChartFormParamModel
    {
        /// <summary>
        /// 图表数据模型列表
        /// </summary>
        public List<ChartDataModel> ChartDataModels { get; set; }
        /// <summary>
        /// 横坐标
        /// </summary>
        public string[] Labels { get; set; }
        /// <summary>
        /// 标记
        /// </summary>
        public string CavityName { get; set; }
        /// <summary>
        /// 数据对应的配方名称
        /// </summary>
        public string[] Recipe { get; set; }

    }
    public class ChartDataModel
    {
        /// <summary>
        /// 数据描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public double[] Data { get; set; }
    }
    public class Palette
    {
        public static Color[] GetColors()
        {
            var knowColors = GetKnownColors();
            List<Color> colorList = new List<Color>(knowColors.Length);
            for (int i = 0; i < knowColors.Length; i++)
            {
                colorList.Add(Color.FromName(knowColors[i].ToString()));
            }
            return colorList.ToArray();
        }
        private static KnownColor[] GetKnownColors()
        {
            System.Array colorsArray = Enum.GetValues(typeof(KnownColor));
            var allColors = new KnownColor[colorsArray.Length];
            Array.Copy(colorsArray, allColors, colorsArray.Length);
            return allColors;
        }
        //使用方式ColorTranslator.FromHtml(Palette.HexColors[i]); 
        public static readonly string[] HexColors =
    {
        "#1f77b4", "#aec7e8", "#ff7f0e", "#ffbb78", "#2ca02c",
        "#98df8a", "#d62728", "#ff9896", "#9467bd", "#c5b0d5",
        "#8c564b", "#c49c94", "#e377c2", "#f7b6d2", "#7f7f7f",
        "#c7c7c7", "#bcbd22", "#dbdb8d", "#17becf", "#9edae5",
    };
        public static readonly string[] HexColors2 =
    {
        "#e6194B","#1f77b4", "#aec7e8", "#ff7f0e", "#ffbb78", "#000000","#2ca02c",
        "#98df8a", "#d62728", "#ff9896", "#9467bd", "#c5b0d5",
        "#8c564b", "#c49c94", "#e377c2", "#f7b6d2","#000075","#17becf", "#9edae5", "#7f7f7f",
        "#c7c7c7", "#bcbd22", "#dbdb8d", "#17becf", "#9edae5",
    };  // 红 + 不同颜色深浅。
        public static readonly string[] HexDeepColors =
        {
            "#1f77b4", "#ff7f0e", "#2ca02c",
            "#d62728", "#9467bd", "#8c564b",
            "#e377c2", "#7f7f7f", "#bcbd22",
            "#17becf",
        };
        public static readonly string[] HexColors3 =
        {
             "#e6194B", "#3cb44b", "#4363d8",
            "#f58231", "#911eb4", "#17becf",
            "#469990", "#9A6324", "#800000",
            "#808000", "#000075", "#1f77b4",
        };
    }
}

