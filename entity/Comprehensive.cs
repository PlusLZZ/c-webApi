using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API调用第二版.service;
using API调用第二版.utils;

namespace API调用第二版.entity
{
  public  class Comprehensive
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
        public Dictionary<string, object> headers { get; set; }
        public List<Param> Params { get; set; }
        /// <summary>
        /// 调用得到的返回值
        /// </summary>
        public object result = null;

        /// <summary>
        /// 调用接口地址
        /// </summary>
        public void Invoke() {
            GetParamsInvoke();//检查参数
           result=  new WebApiClient(Params, Url, headers).Call();
        }

        /// <summary>
        ///检查参数列表中每一个参数是否有值,如果没有值,就通过获取的地址来进行调用返回 
        /// </summary>
        private void GetParamsInvoke() {
            foreach (Param p in Params) {
                if (!p.ishaveValue()) {
                    if (p.paramSource == ParamSource.urlReturn) {
                        foreach (Comprehensive com in ApiFlowAdapter.Adapter) {
                            if (p.ParamForUrl == com.Url) {
                                com.Invoke();
                                p.paraValue = com.result;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
