using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using UGF.JsonNet.Runtime.Converters;

namespace UGF.JsonNet.Runtime.Tests.Converters
{
    public class TestPropertyNameConverts
    {
        private class Target
        {
            public List<object> Targets { get; set; } = new List<object>();
        }

        private class Target1
        {
            public int IntValue { get; set; } = 10;
            public float FloatValue { get; set; } = 10.5F;
        }

        private class Target2
        {
            public bool BoolValue { get; set; } = true;
            public int IntValue { get; set; } = 10;
        }

        [Test]
        public void ToJson()
        {
            var target = new Target()
            {
                Targets =
                {
                    new Target1(),
                    new Target2()
                }
            };

            var serializer = JsonSerializer.CreateDefault(JsonNetUtility.DefaultSettings);

            var writer = new ConvertPropertyNameWriter(new Dictionary<string, string>
            {
                { "$type", "type" }
            });

            serializer.Serialize(writer, target);

            string result = writer.TextWriter.ToString();

            result = JsonNetUtility.Format(result);

            Assert.Pass(result);
        }

        [Test]
        public void ToJsonWithBinder()
        {
            var target = new Target()
            {
                Targets =
                {
                    new Target1(),
                    new Target2()
                }
            };

            var binder = new ConvertTypeNameBinder();
            JsonSerializerSettings settings = JsonNetUtility.CreateDefault();

            settings.SerializationBinder = binder;

            binder.Provider.Add<Target1>("target1");
            binder.Provider.Add<Target2>("target2");

            var serializer = JsonSerializer.CreateDefault(settings);

            var writer = new ConvertPropertyNameWriter(new Dictionary<string, string>
            {
                { "$type", "type" }
            });

            serializer.Serialize(writer, target);

            string result = writer.TextWriter.ToString();

            result = JsonNetUtility.Format(result);

            Assert.Pass(result);
        }

        [Test]
        public void FromJson()
        {
            var target = new Target()
            {
                Targets =
                {
                    new Target1(),
                    new Target2()
                }
            };

            var serializer = JsonSerializer.CreateDefault(JsonNetUtility.DefaultSettings);

            var writer = new ConvertPropertyNameWriter(new Dictionary<string, string>
            {
                { "$type", "type" }
            });

            serializer.Serialize(writer, target);

            string result = writer.TextWriter.ToString();

            Assert.IsNotEmpty(result);

            var reader = new ConvertPropertyNameReader(new Dictionary<string, string>
            {
                { "type", "$type" }
            }, result);

            var result2 = serializer.Deserialize<Target>(reader);

            Assert.NotNull(result2);
            Assert.IsNotEmpty(result2.Targets);
            Assert.AreEqual(2, result2.Targets.Count);
        }

        [Test]
        public void FromJsonWithBinder()
        {
            var target = new Target()
            {
                Targets =
                {
                    new Target1(),
                    new Target2()
                }
            };

            var binder = new ConvertTypeNameBinder();
            JsonSerializerSettings settings = JsonNetUtility.CreateDefault();

            settings.SerializationBinder = binder;

            binder.Provider.Add<Target1>("target1");
            binder.Provider.Add<Target2>("target2");

            var serializer = JsonSerializer.CreateDefault(settings);

            var writer = new ConvertPropertyNameWriter(new Dictionary<string, string>
            {
                { "$type", "type" }
            });

            serializer.Serialize(writer, target);

            string result = writer.TextWriter.ToString();

            Assert.IsNotEmpty(result);

            var reader = new ConvertPropertyNameReader(new Dictionary<string, string>
            {
                { "type", "$type" }
            }, result);

            var result2 = serializer.Deserialize<Target>(reader);

            Assert.NotNull(result2);
            Assert.IsNotEmpty(result2.Targets);
            Assert.AreEqual(2, result2.Targets.Count);
        }
    }
}
