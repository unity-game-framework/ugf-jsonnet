using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using UGF.JsonNet.Runtime.Converters;

namespace UGF.JsonNet.Runtime.Tests.Converters
{
    public class TestConvertTypeNameBinder
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

            var binder = new ConvertTypeNameBinder();
            JsonSerializerSettings settings = JsonNetUtility.CreateDefault();

            settings.SerializationBinder = binder;

            binder.Provider.Add<Target1>("target1");
            binder.Provider.Add<Target2>("target2");

            string result = JsonNetUtility.ToJson(target, settings, true);

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

            var binder = new ConvertTypeNameBinder();
            JsonSerializerSettings settings = JsonNetUtility.CreateDefault();

            settings.SerializationBinder = binder;

            binder.Provider.Add<Target1>("target1");
            binder.Provider.Add<Target2>("target2");

            string result = JsonNetUtility.ToJson(target, settings);
            var result2 = JsonNetUtility.FromJson<Target>(result, settings);

            Assert.NotNull(result2);
            Assert.IsNotEmpty(result2.Targets);
            Assert.AreEqual(2, result2.Targets.Count);
        }
    }
}
