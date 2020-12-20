using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace UGF.JsonNet.Runtime.Converters
{
    public class ConvertPropertyNameReader : JsonTextReader
    {
        public IReadOnlyDictionary<string, string> Names { get; }
        public TextReader Reader { get; }

        public ConvertPropertyNameReader(IReadOnlyDictionary<string, string> names, string text) : this(names, new StringReader(text))
        {
        }

        public ConvertPropertyNameReader(IReadOnlyDictionary<string, string> names, TextReader reader) : base(reader)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            Reader = reader;
        }

        public override bool Read()
        {
            bool result = base.Read();

            if (result && TokenType == JsonToken.PropertyName && Value is string name)
            {
                if (Names.TryGetValue(name, out string value))
                {
                    SetToken(JsonToken.PropertyName, value);
                }
            }

            return result;
        }
    }
}
