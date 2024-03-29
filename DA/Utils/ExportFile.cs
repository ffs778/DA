using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA
{
    /// <summary>
    /// XLS 文件：
    /// XLS 是 Microsoft Excel 的二进制文件格式，用于存储电子表格数据。
    /// XLS 文件可以包含多个工作表、公式、图表、宏等复杂的电子表格功能。
    /// XLS 文件通常较大，因为它们包含了大量的元数据和格式设置。
    /// 由于是二进制格式，XLS 文件在不同的软件中可能存在兼容性问题。
    /// CSV 文件（逗号分隔值文件）：
    /// CSV 是一种简单的文本文件格式，用逗号或其他分隔符来分隔数据。
    /// CSV 文件只包含纯文本数据，没有样式、格式设置或其他元数据。
    /// CSV 文件通常比较小，因为它们只包含原始数据，不包含其他内容。
    /// CSV 文件易于生成、解析和导入到各种应用程序中，具有良好的跨平台和跨软件兼容性。
    /// </summary>
    public class ExportFile
    {
        /// <summary>
        /// 导出带标题行的DataTable数据
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="dataTable"></param>
        /// <param name="columnHeaders"></param>
        public static void DataTableToCsv(string fileName, DataTable dataTable, string[] columnHeaders)
        {
            ExportToFile("CSV", fileName, dataTable, columnHeaders);
        }
        /// <summary>
        /// 导出带标题行、标题列的DataTable数据
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="dataTable"></param>
        /// <param name="columnHeaders"></param>
        /// <param name="rowHeaders"></param>
        public static void DataTableToCsv(string fileName, DataTable dataTable, string[] columnHeaders, string[] rowHeaders)
        {
            ExportToFile("CSV", fileName, dataTable, columnHeaders, rowHeaders);
        }
        /// <summary>
        /// 导出带标题行的DataTable数据
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="dataTable"></param>
        /// <param name="columnHeaders"></param>
        public static void DataTableToExcel(string fileName, DataTable dataTable, string[] columnHeaders)
        {
            ExportToFile("Excel", fileName, dataTable, columnHeaders);
        }
        /// <summary>
        /// 导出带标题行、标题列的DataTable数据
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="dataTable"></param>
        /// <param name="columnHeaders"></param>
        /// <param name="rowHeaders"></param>
        public static void DataTableToExcel(string fileName, DataTable dataTable, string[] columnHeaders, string[] rowHeaders)
        {
            ExportToFile("Excel", fileName, dataTable, columnHeaders, rowHeaders);
        }

        private static void ExportToFile(string fileType, string fileName, DataTable dataTable, string[] columnHeaders)
        {
            string filter = fileType == "CSV" ? "CSV files (*.csv)|*.csv" : "Execl files (*.xls)|*.xls";
            string separator = fileType == "CSV" ? "," : "\t";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filter;
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = fileName + " " + DateTime.Now.ToLongDateString();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = $"导出{fileType}文件";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Task.Run(() =>
                {
                    Stream myStream;
                    myStream = saveFileDialog.OpenFile();
                    StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.Default);
                    try
                    {
                        sw.WriteLine(string.Join(separator, columnHeaders));                 // 列标题行
                        foreach (DataRow row in dataTable.Rows)
                        {
                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                sw.Write(row[i].ToString());                                // 数据
                                if (i < dataTable.Columns.Count - 1) sw.Write(separator);   // 换列符
                            }
                            sw.WriteLine();
                        }
                        sw.Close();
                        myStream.Close();
                        MessageBox.Show("数据导出成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导出失败！" + ex.ToString());
                    }
                    finally
                    {
                        sw.Close();
                        myStream.Close();
                    }
                });
            }
        }
        private static void ExportToFile(string fileType, string fileName, DataTable dataTable, string[] columnHeaders, string[] rowHeaders)
        {
            string filter = fileType == "CSV" ? "CSV files (*.csv)|*.csv" : "Execl files (*.xls)|*.xls";
            string separator = fileType == "CSV" ? "," : "\t";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filter;
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.FileName = fileName + " " + DateTime.Now.ToLongDateString();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = $"导出{fileType}文件";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Task.Run(() =>
                {
                    Stream myStream;
                    myStream = saveFileDialog.OpenFile();
                    StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.Default);
                    try
                    {
                        sw.WriteLine($"{separator}{string.Join(separator, columnHeaders)}");  // 列标题行,第一列为空
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataTable.Columns.Count; j++)
                            {
                                if (j == 0) sw.Write($"{rowHeaders[i]}{ separator}");        // 行标题
                                sw.Write(dataTable.Rows[i][j].ToString());                   // 数据
                                if (j < dataTable.Columns.Count - 1) sw.Write(separator);    // 换列符
                            }
                            sw.WriteLine();
                        }
                        sw.Close();
                        myStream.Close();
                        MessageBox.Show("数据导出成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导出失败！" + ex.ToString());
                    }
                    finally
                    {
                        sw.Close();
                        myStream.Close();
                    }
                });
            }
        }
    }
}
