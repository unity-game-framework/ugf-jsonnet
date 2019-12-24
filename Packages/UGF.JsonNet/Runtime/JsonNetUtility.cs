using System;
using System.IO;
using Newtonsoft.Json;

namespace UGF.JsonNet.Runtime
{
    public static class JsonNetUtility
    {
        public static JsonSerializerSettings DefaultSettings { get; } = new JsonSerializerSettings
        {
            ContractResolver = new JsonNetContractResolver(),
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        public static string ToJson(object target, JsonSerializerSettings settings = null)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));

            return JsonConvert.SerializeObject(target, settings ?? DefaultSettings);
        }

        public static T FromJson<T>(string text, JsonSerializerSettings settings = null)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentException("Value cannot be null or empty.", nameof(text));

            return JsonConvert.DeserializeObject<T>(text, settings ?? DefaultSettings);
        }

        public static string Format(string text, Formatting formatting = Formatting.None)
        {
            using (var reader = new StringReader(text))
            using (var writer = new StringWriter())
            {
                var jsonReader = new JsonTextReader(reader);
                var jsonWriter = new JsonTextWriter(writer) { Formatting = formatting };

                jsonWriter.WriteToken(jsonReader);

                return writer.ToString();
            }
        }
    }
}
