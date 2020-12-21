using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UGF.JsonNet.Runtime.Converters
{
    public class ConvertPropertyNameWriter : JsonTextWriter
    {
        public IReadOnlyDictionary<string, string> Names { get; }
        public TextWriter TextWriter { get; }

        public ConvertPropertyNameWriter(IReadOnlyDictionary<string, string> names) : this(names, new StringWriter(CultureInfo.InvariantCulture))
        {
        }

        public ConvertPropertyNameWriter(IReadOnlyDictionary<string, string> names, TextWriter textWriter) : base(textWriter)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            TextWriter = textWriter;
        }

        public override Task WritePropertyNameAsync(string name, CancellationToken cancellationToken = new CancellationToken())
        {
            name = Convert(name);

            return base.WritePropertyNameAsync(name, cancellationToken);
        }

        public override Task WritePropertyNameAsync(string name, bool escape, CancellationToken cancellationToken = new CancellationToken())
        {
            name = Convert(name);

            return base.WritePropertyNameAsync(name, escape, cancellationToken);
        }

        public override void WritePropertyName(string name)
        {
            name = Convert(name);

            base.WritePropertyName(name);
        }

        public override void WritePropertyName(string name, bool escape)
        {
            name = Convert(name);

            base.WritePropertyName(name, escape);
        }

        private string Convert(string name)
        {
            return Names.TryGetValue(name, out string value) ? value : name;
        }

        public override string ToString()
        {
            return TextWriter.ToString();
        }
    }
}
