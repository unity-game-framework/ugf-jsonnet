using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace UGF.JsonNet.Runtime
{
    public class JsonNetContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = (List<JsonProperty>)base.CreateProperties(type, memberSerialization);

            properties.Sort(JsonNetPropertyInheritanceCountComparer.Default);

            return properties;
        }

        protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
        {
            JsonDictionaryContract contract = base.CreateDictionaryContract(objectType);

            contract.DictionaryKeyResolver = name => name;

            return contract;
        }
    }
}
