using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API调用第二版.entity;

namespace API调用第二版.utils
{
   public static class ParamUtils
    {
        /// <summary>
        /// 将参数列表转换成get请求后面的字符串
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ParaListConversionToGet(List<Param> list) {
            if (list == null && list.Count == 0)
            {
                return "";
            }
            else {
                StringBuilder sb = new StringBuilder();
                sb.Append("?");
                foreach (Param p in list)
                {
                    if (p.paraName != null)
                    {
                        sb.Append(p.paraName);
                        sb.Append("=");
                        byte[] buffer = Encoding.UTF8.GetBytes(p.paraValue.ToString());
                        string s = Encoding.UTF8.GetString(buffer);
                        sb.Append(s);
                        sb.Append("&");
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
        
        }

        /// <summary>
        /// 将参数列表动态转换为一个可以通过json序列化的对象类型
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static object ParaListConversion(List<Param> list) {
            if (list.Count > 1)
            {
                dynamic d = new System.Dynamic.ExpandoObject();
                //创建属性,并赋值
                foreach (Param ps in list)
                {
                    (d as System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>).Add
                        (new System.Collections.Generic.KeyValuePair<string, object>(ps.paraName, ps.paraValue));
                }
                return d;
            }
            else
            {
                //如果是单个基本类型,或者是数组,就直接返回
                return list[0].paraValue;
            }
        }
    }
}
