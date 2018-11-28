using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common
{
    public static class Extension
    {
        public static int ToInt(this string str)
        {
            int t = 0;
            int.TryParse(str, out t);
            return t;
        }
        public static T ToEntity<T>(this string json) where T : class
        {
            var setting = new JsonSerializerSettings();
            setting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.DeserializeObject<T>(json, setting);
        }
        public static string ToJson(this object obj)
        {
            var setting = new JsonSerializerSettings();
            setting.NullValueHandling = NullValueHandling.Ignore;
            setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            return JsonConvert.SerializeObject(obj, setting);
        }

    }
}
