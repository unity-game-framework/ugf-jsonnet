using System;
using System.Collections.Generic;

namespace UGF.JsonNet.Runtime.Converters
{
    public interface IConvertTypeProvider
    {
        IReadOnlyCollection<ConvertTypeInfo> Infos { get; }

        void Add<T>(string typeName);
        void Add(Type type, string typeName);
        void Add(Type type, string typeName, string assemblyName);
        void Add(ConvertTypeInfo info);
        bool Remove(string typeName);
        bool Remove(string typeName, string assemblyName);
        bool Remove(Type type);
        bool Remove(ConvertTypeInfo info);
        ConvertTypeInfo Get(string typeName);
        ConvertTypeInfo Get(string typeName, string assemblyName);
        ConvertTypeInfo Get(Type type);
        bool TryGet(string typeName, out ConvertTypeInfo info);
        bool TryGet(string typeName, string assemblyName, out ConvertTypeInfo info);
        bool TryGet(Type type, out ConvertTypeInfo info);
    }
}
