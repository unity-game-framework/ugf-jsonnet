using System;

namespace UGF.JsonNet.Runtime.Converters
{
    public readonly struct ConvertTypeInfo : IEquatable<ConvertTypeInfo>
    {
        public Type Type { get; }
        public string Name { get; }
        public string Assembly { get; }
        public bool HasAssembly { get { return !string.IsNullOrEmpty(Assembly); } }

        public ConvertTypeInfo(Type type, string name) : this(type, name, string.Empty)
        {
        }

        public ConvertTypeInfo(Type type, string name, string assembly)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            Type = type ?? throw new ArgumentNullException(nameof(type));
            Name = name;
            Assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
        }

        public bool IsValid()
        {
            return Type != null && !string.IsNullOrEmpty(Name);
        }

        public bool Equals(ConvertTypeInfo other)
        {
            return Type == other.Type && Name == other.Name && Assembly == other.Assembly;
        }

        public override bool Equals(object obj)
        {
            return obj is ConvertTypeInfo other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Type != null ? Type.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Assembly != null ? Assembly.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(ConvertTypeInfo first, ConvertTypeInfo second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(ConvertTypeInfo first, ConvertTypeInfo second)
        {
            return !first.Equals(second);
        }

        public override string ToString()
        {
            string assembly = HasAssembly ? $", {Assembly}" : string.Empty;

            return $"{Type} ({Name}{assembly})";
        }
    }
}
