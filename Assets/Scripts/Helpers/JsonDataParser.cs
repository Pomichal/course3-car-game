using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Helpers
{
    public static class JsonDataParser
    {
        public static T LoadFromResources<T>(string path)
        {
            try
            {
                TextAsset jsonString;
                jsonString = Resources.Load<TextAsset>(path);
                return JsonConvert.DeserializeObject<T>(jsonString.text);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), MessageTypes.Error, 1);
                return default;
            }
        }

        public static T LoadFromPersistentPath<T>(string path)
        {
            try
            {
                StreamReader r = new StreamReader(path);
                string jsonString = r.ReadToEnd();
                r.Close();
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), MessageTypes.Error, 1);
                return default;
            }
        }

        public static void WriteToPersistentData(object obj, string path)
        {
            string jsonString = JsonConvert.SerializeObject(obj);
            try
            {
                File.WriteAllText(path, jsonString);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), MessageTypes.Error, 1);
            }

        }
    }
}

