using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //public static TTo MapObject<TFrom, TTo>(this TFrom value)
        //{
        //    return Mapper.Map<TTo>(value);
        //}

        //public static IEnumerable<TTo> MapListObject<TFrom, TTo>(this IEnumerable<TFrom> values)
        //{
        //    return values.Select(x => Mapper.Map<TTo>(x)).ToList();
        //}

    }
}
