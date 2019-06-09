using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DNB.Supermarket.WebUI.ExtensionMethods
{
    //Extension metod oluşturabilmek için bu class static olmalı.
    public static class SessionExtensionMethods
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string objString = JsonConvert.SerializeObject(value);
            session.SetString(key, objString);
        }

        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string objString = session.GetString(key);

            if (string.IsNullOrEmpty(objString))
                return null;

            T value = JsonConvert.DeserializeObject<T>(objString);
            return value;
        }
    }
}
