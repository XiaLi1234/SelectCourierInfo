using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchForm.common
{
    public static class JsonNewtonsoft
    {
        /// <summary>
        /// 把对象转换为JSON字符串
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>JSON字符串</returns>
        public static string ToJSON(this object o)
        {
            if (o == null)
            {
                return null;
            }
            return JsonConvert.SerializeObject(o);
        }
        /// <summary>
        /// 把Json文本转为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T FromJSON<T>(this string input)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string[] parts = input.Split(new char[] { '\n', '\t', '\r', '\f', '\v' }, StringSplitOptions.RemoveEmptyEntries);
                int size = parts.Length;
                for (int i = 0; i < size; i++)
                    sb.AppendFormat("{0}", parts[i]);
                return JsonConvert.DeserializeObject<T>(sb.ToString());
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
