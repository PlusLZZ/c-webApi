using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API调用第二版.utils
{
  public static  class TypeDic
    {
        public static readonly Dictionary<string, Type> _Types = new Dictionary<string, Type> {
            {"byte",typeof(byte) },
            {"sbyte",typeof(sbyte) },
            {"short",typeof(short) },
            {"ushort",typeof(ushort) },
            {"int",typeof(int) },
            {"uint",typeof(uint) },
            {"long",typeof(long) },
            {"ulong",typeof(ulong) },
            {"float",typeof(float) },
            {"double",typeof(double) },
            {"decimal",typeof(decimal) },
            {"bool",typeof(bool) },
            {"string",typeof(string) },
            {"char",typeof(char) },
            {"datetime",typeof(DateTime) },
            {"byte[]",typeof(byte[]) },
            {"string[]",typeof(string[]) },
            {"char[]",typeof(char[]) },
            {"sbyte[]",typeof(sbyte[]) },
            {"short[]",typeof(short[]) },
            {"ushort[]",typeof(ushort[]) },
            {"int[]",typeof(int[]) },
            {"uint[]",typeof(uint[]) },
            {"long[]",typeof(long[]) },
            {"ulong[]",typeof(ulong[]) },
            {"float[]",typeof(float[]) },
            {"double[]",typeof(double[]) },
            {"decimal[]",typeof(decimal[]) }
        };
    }
}
