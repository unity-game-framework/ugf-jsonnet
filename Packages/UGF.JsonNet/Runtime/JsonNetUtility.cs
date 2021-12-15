using System;
using System.IO;
using Newtonsoft.Json;

namespace UGF.JsonNet.Runtime
{
    public static class JsonNetUtility
    {
        public static JsonSerializerSettings DefaultSettings { get; } = CreateDefault();

        public static JsonSerializerSettings CreateDefault()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new JsonNetContractResolver(),
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public static string ToJson<T>(T target, bool readable = false)
        {
            return ToJson(target, DefaultSettings, readable);
        }

        public static string ToJson<T>(T target, JsonSerializerSettings settings, bool readable = false)
        {
            return ToJson(target, typeof(T), settings, readable);
        }

        public static string ToJson(object target, bool readable = false)
        {
            return ToJson(target, DefaultSettings, readable);
        }

        public static string ToJson(object target, JsonSerializerSettings settings, bool readable = false)
        {
            return ToJson(target, typeof(object), settings, readable);
        }

        public static string ToJson(object target, Type targetType, JsonSerializerSettings settings, bool readable = false)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (targetType == null) throw new ArgumentNullException(nameof(targetType));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            string text = JsonConvert.SerializeObject(target, targetType, settings);

            if (readable)
            {
                text = Format(text);
            }

            return text;
        }

        public static T FromJson<T>(string text)
        {
            return FromJson<T>(text, DefaultSettings);
        }

        public static T FromJson<T>(string text, JsonSerializerSettings settings)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentException("Value cannot be null or empty.", nameof(text));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            return JsonConvert.DeserializeObject<T>(text, settings);
        }

        public static object FromJson(string text, Type type)
        {
            return FromJson(text, type, DefaultSettings);
        }

        public static object FromJson(string text, Type type, JsonSerializerSettings settings)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentException("Value cannot be null or empty.", nameof(text));
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            return JsonConvert.DeserializeObject(text, type, settings);
        }

        public static string Format(string text, bool readable = true, int indent = 2)
        {
            if (indent < 0) throw new ArgumentOutOfRangeException(nameof(indent));

            using (var reader = new StringReader(text))
            using (var writer = new StringWriter())
            {
                var jsonReader = new JsonTextReader(reader);

                var jsonWriter = new JsonTextWriter(writer)
                {
                    Formatting = readable ? Formatting.Indented : Formatting.None,
                    Indentation = indent
                };

                jsonWriter.WriteToken(jsonReader);

                return writer.ToString();
            }
        }
    }
}
