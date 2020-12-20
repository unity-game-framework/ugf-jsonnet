using System;
using System.Collections.Generic;

namespace UGF.JsonNet.Runtime.Converters
{
    public class ConvertTypeProvider : IConvertTypeProvider
    {
        public IReadOnlyCollection<ConvertTypeInfo> Infos { get { return m_infos; } }

        private readonly HashSet<ConvertTypeInfo> m_infos = new HashSet<ConvertTypeInfo>();
        private readonly Dictionary<Type, ConvertTypeInfo> m_infoByType = new Dictionary<Type, ConvertTypeInfo>();
        private readonly Dictionary<(string, string), ConvertTypeInfo> m_infoByName = new Dictionary<(string, string), ConvertTypeInfo>();

        public void Add(ConvertTypeInfo info)
        {
            if (!info.IsValid()) throw new ArgumentException("Value should be valid.", nameof(info));

            m_infos.Add(info);
            m_infoByType.Add(info.Type, info);
            m_infoByName.Add((info.Name, info.Assembly), info);
        }

        public bool Remove(string typeName)
        {
            return TryGet(typeName, out ConvertTypeInfo info) && Remove(info);
        }

        public bool Remove(string typeName, string assemblyName)
        {
            return TryGet(typeName, assemblyName, out ConvertTypeInfo info) && Remove(info);
        }

        public bool Remove(Type type)
        {
            return TryGet(type, out ConvertTypeInfo info) && Remove(info);
        }

        public bool Remove(ConvertTypeInfo info)
        {
            if (!info.IsValid()) throw new ArgumentException("Value should be valid.", nameof(info));

            if (m_infos.Remove(info))
            {
                m_infoByType.Remove(info.Type);
                m_infoByName.Remove((info.Name, info.Assembly));
                return true;
            }

            return false;
        }

        public ConvertTypeInfo Get(string typeName)
        {
            return TryGet(typeName, out ConvertTypeInfo info) ? info : throw new ArgumentException($"Type info not found by the specified type name: '{typeName}'.");
        }

        public ConvertTypeInfo Get(string typeName, string assemblyName)
        {
            return TryGet(typeName, assemblyName, out ConvertTypeInfo info) ? info : throw new ArgumentException($"Type info not found by the specified type name and assembly name: '{typeName}', '{assemblyName}'.");
        }

        public ConvertTypeInfo Get(Type type)
        {
            return TryGet(type, out ConvertTypeInfo info) ? info : throw new ArgumentException($"Type info not found by the specified type: '{type}'.");
        }

        public bool TryGet(string typeName, out ConvertTypeInfo info)
        {
            if (string.IsNullOrEmpty(typeName)) throw new ArgumentException("Value cannot be null or empty.", nameof(typeName));

            return m_infoByName.TryGetValue((typeName, string.Empty), out info);
        }

        public bool TryGet(string typeName, string assemblyName, out ConvertTypeInfo info)
        {
            if (string.IsNullOrEmpty(typeName)) throw new ArgumentException("Value cannot be null or empty.", nameof(typeName));
            if (string.IsNullOrEmpty(assemblyName)) throw new ArgumentException("Value cannot be null or empty.", nameof(assemblyName));

            return m_infoByName.TryGetValue((typeName, assemblyName), out info);
        }

        public bool TryGet(Type type, out ConvertTypeInfo info)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return m_infoByType.TryGetValue(type, out info);
        }

        public HashSet<ConvertTypeInfo>.Enumerator GetEnumerator()
        {
            return m_infos.GetEnumerator();
        }
    }
}
