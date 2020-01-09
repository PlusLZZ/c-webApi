using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API调用第二版.utils;

namespace API调用第二版.entity
{
    public class Param
    {
        public string paraName { get; set; }
        public string paraType { get; set; }
        public Type DBType { get; set; }
        /// <summary>
        /// 枚举参数的来源
        /// </summary>
        public ParamSource paramSource { get; set; }
        public string ParamForUrl { get; set; }
        public object paraValue { get; set; }

        /// <summary>
        /// 判断是否有值
        /// </summary>
        /// <returns></returns>
        public bool ishaveValue() {
            if (paraValue == null)
            {
                return false;
            }
            else {
                valueToType();
                return true;
            }
        }

        /// <summary>
        /// 给DBType赋值
        /// </summary>
        private void valueToType() {
            try {
                if (TypeDic._Types.ContainsKey(paraType.ToLower()))
                {
                    DBType = TypeDic._Types[paraType];
                }
                else {
                    DBType = typeof(object);
                }            }
            catch (Exception ex) { 
            
            }
        }

        /// <summary>
        /// 将值按照Type转换
        /// </summary>
        private void valueForType() {
            paraValue = Convert.ChangeType(paraValue, DBType);
        }

        /// <summary>
        /// 获取value值
        /// </summary>
        public void GetValue() { 
        
        }

    }
}
