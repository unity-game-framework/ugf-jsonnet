using System;
using Newtonsoft.Json.Serialization;

namespace UGF.JsonNet.Runtime.Converters
{
    public class ConvertTypeNameBinder : ISerializationBinder
    {
        public IConvertTypeProvider Provider { get; }
        public ISerializationBinder DefaultBinder { get; }

        public ConvertTypeNameBinder() : this(new ConvertTypeProvider(), new DefaultSerializationBinder())
        {
        }

        public ConvertTypeNameBinder(IConvertTypeProvider provider, ISerializationBinder defaultBinder)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            DefaultBinder = defaultBinder ?? throw new ArgumentNullException(nameof(defaultBinder));
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            if (!string.IsNullOrEmpty(assemblyName))
            {
                return Provider.TryGet(typeName, assemblyName, out ConvertTypeInfo info)
                    ? info.Type
                    : DefaultBinder.BindToType(assemblyName, typeName);
            }
            else
            {
                return Provider.TryGet(typeName, out ConvertTypeInfo info)
                    ? info.Type
                    : DefaultBinder.BindToType(assemblyName, typeName);
            }
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            if (Provider.TryGet(serializedType, out ConvertTypeInfo info))
            {
                typeName = info.Name;
                assemblyName = !string.IsNullOrEmpty(info.Assembly) ? info.Assembly : null;
            }
            else
            {
                DefaultBinder.BindToName(serializedType, out assemblyName, out typeName);
            }
        }
    }
}
