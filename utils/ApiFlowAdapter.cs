using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API调用第二版.entity;

namespace API调用第二版.utils
{
  public static class ApiFlowAdapter
    {
        public static List<Comprehensive> Adapter = null;

        public static void setValue(List<Comprehensive> values) {
            Adapter = values;
        }


       
    }
}
