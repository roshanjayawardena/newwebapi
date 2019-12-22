using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Extentions
{
    public static class ObjectExtention
    {
        public static bool IsNull(this object value)
        {
            return value == null;
        }

        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

    }
}
