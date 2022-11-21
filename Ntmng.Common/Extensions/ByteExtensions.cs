using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntmng.Common.Extensions
{
    public static class ByteExtensions
    {
        public static string ToStringFromArrary(this byte[] array)
        {
            return System.Text.Encoding.UTF8.GetString(array);
        }
    }
}