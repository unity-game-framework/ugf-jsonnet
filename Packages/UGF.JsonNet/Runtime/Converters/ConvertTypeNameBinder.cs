using System;
using Newtonsoft.Json.Serialization;

namespace UGF.JsonNet.Runtime.Converters
{
    public class ConvertTypeNameBinder : ISerializationBinder
    {
        public IConvertTypeProvider Provider { get; }

        public ConvertTypeNameBinder() : this(new ConvertTypeProvider())
        {
        }

        public ConvertTypeNameBinder(IConvertTypeProvider provider)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            ConvertTypeInfo info = !string.IsNullOrEmpty(assemblyName) ? Provider.Get(typeName, assemblyName) : Provider.Get(typeName);

            return info.Type;
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            ConvertTypeInfo info = Provider.Get(serializedType);

            assemblyName = info.Assembly;
            typeName = info.Name;
        }
    }
}
