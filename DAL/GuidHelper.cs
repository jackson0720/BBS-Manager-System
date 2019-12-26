using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GuidHelper
    {
        /// <summary>
        /// GUID生成
        /// </summary>
        /// <param name="format">格式 可填写N、D、B、P、X</param>
        /// <returns></returns>
        public static string GetNewGuId(string format = "")
        {
            if (string.IsNullOrWhiteSpace(format))
                return Guid.NewGuid().ToString().ToUpper();
            else
                return Guid.NewGuid().ToString(format).ToUpper();
        }
    }
}
