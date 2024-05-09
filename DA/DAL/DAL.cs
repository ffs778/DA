using DA.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class DAL
    {
        /// <summary>
        /// 获得表中的全部数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetData(string tableName)
        {
            string commandText = $"select * from [{tableName}] order by 数据采集时间 Desc;";
            return DBHelper.Instance.CheckSQL(commandText);
        }
        /// <summary>
        /// 返回数据库中的所有表名
        /// </summary>
        /// <returns></returns>
        public static string[] GetTableName()
        {
            string commandText = $"SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;";
            DataTable data = DBHelper.Instance.CheckSQL(commandText);
            List<string> nameList = new List<string>(data.Rows.Count);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                nameList.Add(data.Rows[i][0].ToString());
            }
            return nameList.ToArray();
        }
        /// <summary>
        /// 获得配方名称
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string[] GetRecipes(string tableName)
        {
            string commandText = $"select distinct 配方名称 from [{tableName}];";
            DataTable data = DBHelper.Instance.CheckSQL(commandText);
            List<string> recipeList = new List<string>(data.Rows.Count);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                recipeList.Add(data.Rows[i][0].ToString());
            }
            return recipeList.ToArray();
        }
        /// <summary>
        /// 判断配方字段是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static bool ExistRecipe(string tableName)
        {
            try
            {
                string commandText = $"select 配方名称 from [{tableName}] Limit 1;";
                _ = DBHelper.Instance.CheckSQL(commandText);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获得当前工艺的所有采集时间和工艺步信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="recipeName"></param>
        /// <returns></returns>
        public static DataTable GetTimeAndCraftStep(string tableName, string recipeName)
        {
            string commandText = $"select 数据采集时间,当前工艺步 from [{tableName}] where [配方名称] = '{recipeName}' order by 数据采集时间 Desc";
            return DBHelper.Instance.CheckSQL(commandText);
        }
        /// <summary>
        /// 获得所选配方的全部工艺步
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="recipeName"></param>
        /// <returns></returns>
        public static string[] GetDistinctStep(string tableName, string recipeName)
        {
            string commandText = $"select distinct 当前工艺步 from [{tableName}] where [配方名称] = '{recipeName}' order by cast (当前工艺步 AS INTEGER);   ";
            var data = DBHelper.Instance.CheckSQL(commandText);
            List<string> stepList = new List<string>(data.Rows.Count);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                stepList.Add(data.Rows[i][0].ToString());
            }
            return stepList.ToArray();
        }
        /// <summary>
        /// 获得当前配方，当前步的所有工艺时间
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="recipeName"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static string[] GetDistinctTime(string tableName, string recipeName, string step)
        {
            string commandText = $"select distinct 当前工艺时间 from [{tableName}] where [配方名称] = '{recipeName}' and [当前工艺步] = '{step}' order by cast (当前工艺时间 AS INTEGER);   ";
            var data = DBHelper.Instance.CheckSQL(commandText);
            List<string> timeList = new List<string>(data.Rows.Count);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                timeList.Add(data.Rows[i][0].ToString());
            }
            return timeList.ToArray();
        }














        /// <summary>
        /// 导入csv文件
        /// 列名作为数据库字段，文件名作为表名
        /// </summary>
        /// <param name="path">文件路径</param>
        public static async void ImportCsvFile(string path, EncodingType encodingType)
        {
            await Task.Run(() =>
            {
                Encoding encoding = default;
                switch (encodingType)
                {
                    case EncodingType.GB2312:encoding = EncodingEx.GB2312;
                        break;
                    case EncodingType.UTF8:encoding = Encoding.UTF8;
                        break;
                }
                var lines = File.ReadAllLines(path, encoding);
                // 1. 文件内容未知，因此先读取第一行csv内容。获取字段数量、列名
                var fields = lines[0].Split(',');
                var tableName = Path.GetFileNameWithoutExtension(path); ; // 文件名
                CreateTable(tableName, fields);
                // 3.读取CSV文件内容，插入数据库表中
                
                StringBuilder valuesSb = new StringBuilder();
                var valuesLines = lines.Skip(1).ToArray();// 跳过标题行
                for (int i = 0; i < valuesLines.Length; i++)
                {
                    valuesSb.Append($"('{valuesLines[i].Replace(",", "','")}')");
                    if (i < valuesLines.Length - 1) valuesSb.Append(',');
                }
                string commandText = $"insert into [{tableName}] values{valuesSb}";
                DBHelper.Instance.ExecuteSQL(commandText);

            });
            NotifyMessage.ShowSuccess("数据导入成功!");
        }
        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        private static void CreateTable(string tableName, string[] fields)
        {
            var fieldCount = fields.Length;
            // 2. 根据列名和数量生成数据表
            StringBuilder fieldsSb = new StringBuilder();
            for (int i = 0; i < fields.Length; i++)
            {
                fieldsSb.Append($"[{fields[i]}] TEXT");
                if (i < fields.Length - 1) fieldsSb.Append(", ");
            }
            string commandText = $"CREATE TABLE [{tableName}] ({fieldsSb});";
            DBHelper.Instance.ExecuteSQL(commandText);
        }
    }
}
