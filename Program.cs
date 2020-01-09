using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API调用第二版.client;
using API调用第二版.entity;

namespace API调用第二版
{
    class Program
    {
        static void Main(string[] args)
        {
            Param c1p1 = new Param() {paraName="id",paraType="int",paramSource=ParamSource.urlReturn ,ParamForUrl= "https://localhost:44350/test18" };
            Param c1p2 = new Param() { paraName = "name", paraType = "string", paramSource = ParamSource.urlReturn, ParamForUrl = "https://localhost:44350/test17" };
            Param c1p3 = new Param() { paraName = "age", paraType = "int", paramSource = ParamSource.pageTo, paraValue=18 };

            Param c2p1 = new Param() { paraName = "str", paraType = "string", paramSource = ParamSource.pageTo, paraValue ="LIU"};

            Param c3p1 = new Param() { paraName = "code", paraType = "int", paramSource = ParamSource.pageTo, paraValue = 1 };
            Dictionary<string, object> d1 = new Dictionary<string, object> {
                { "Method","get"},{ "ContentType","application/json"}
            };
            Dictionary<string, object> d2 = new Dictionary<string, object> {
                { "Method","get"},{ "ContentType","application/json"}
            };
            Dictionary<string, object> d3 = new Dictionary<string, object> {
                { "Method","post"},{ "ContentType","application/json"}
            };
            Comprehensive c1 = new Comprehensive() { Url = "https://localhost:44350/test16" ,headers=d1,Params=new List<Param> { c1p1,c1p2,c1p3} };
            Comprehensive c2 = new Comprehensive() { Url = "https://localhost:44350/test17" ,headers=d2,Params=new List<Param> { c2p1} };
            Comprehensive c3 = new Comprehensive() { Url = "https://localhost:44350/test18" ,headers=d3,Params=new List<Param> { c3p1} };
            List<Comprehensive> comprehensives = new List<Comprehensive> { c1,c2,c3};
            ApiInvoke api = new ApiInvoke(comprehensives);
            Console.WriteLine(api.getValue("https://localhost:44350/test18"));
            Console.ReadKey();
        }
    }
}
