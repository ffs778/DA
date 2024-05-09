using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Utils
{
    public enum EncodingType
    {
        /// <summary>
        /// 中文简体编码格式
        /// WPS保存的CSV默认中文格式
        /// </summary>
        GB2312,
        /// <summary>
        /// UTF编码格式，
        /// Excel保存的默认编码格式。
        /// </summary>
        UTF8

    }
    public class EncodingEx
    {
        
        /// <summary>
        /// 中文简体编码格式
        /// </summary>
        public static Encoding GB2312
        {
            get
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                return Encoding.GetEncoding("GB2312");
            }
        }
    }
}
