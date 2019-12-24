using System;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace UGF.JsonNet.Runtime
{
    public class JsonNetPropertyInheritanceCountComparer : IComparer<JsonProperty>
    {
        public static JsonNetPropertyInheritanceCountComparer Default { get; } = new JsonNetPropertyInheritanceCountComparer();

        public int Compare(JsonProperty x, JsonProperty y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;

            int xCount = GetInheritanceCount(x.DeclaringType);
            int yCount = GetInheritanceCount(y.DeclaringType);

            return xCount.CompareTo(yCount);
        }

        private static int GetInheritanceCount(Type type)
        {
            int count = 0;

            while (type != null)
            {
                count++;

                type = type.BaseType;
            }

            return count;
        }
    }
}
