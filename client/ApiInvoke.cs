using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API调用第二版.entity;
using API调用第二版.utils;

namespace API调用第二版.client
{
  public  class ApiInvoke
    {
        public List<Comprehensive> comprehensives { get; set; }
        public ApiInvoke(List<Comprehensive> list) {
            this.comprehensives = list;
            ApiFlowAdapter.setValue(comprehensives);
        }

        public string getValue (string Url) {
            foreach (Comprehensive com in comprehensives) {
                if (Url == com.Url) {
                    com.Invoke();
                    return com.result.ToString();
                }
            }
            return "未找到这个接口地址";
        }

    }
}
