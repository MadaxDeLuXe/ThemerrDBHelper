using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemerrDBHelper.Helpers
{
    public static class Json
    {
        public static string Serialize<T>(T obj, JsonSerializerSettings? settings = null)
        {
            return settings is not null ? JsonConvert.SerializeObject(obj, settings) : JsonConvert.SerializeObject(obj);
        }
        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T? DeSerialize<T>(string json, JsonSerializerSettings? settings = null)
        {
            return settings is not null ? JsonConvert.DeserializeObject<T>(json, settings) : JsonConvert.DeserializeObject<T>(json);
        }
        public static T? DeSerialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static bool WriteToDisk<T>(T obj, string path)
        {            
            JsonSerializerSettings settings = new()
            {
                Formatting = Formatting.Indented
            };

            try
            {
                if (!Directory.Exists(path.Substring(0, path.LastIndexOf('\\')))) { Directory.CreateDirectory(path.Substring(0, path.LastIndexOf('\\'))); }

                File.WriteAllText(path, Serialize<T>(obj, settings));
                return true;
            }
            catch (Exception ex)
            {
                // TODO: Exception handling
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static T? LoadFromDisk<T>(string path)
        {
            JsonSerializerSettings settings = new()
            {
                Formatting = Formatting.Indented
            };

            if (!File.Exists(path)) { return default; }

            try
            {
                return DeSerialize<T>(File.ReadAllText(path), settings);
            }
            catch (Exception ex)
            {
                // TODO: Exception handling
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
