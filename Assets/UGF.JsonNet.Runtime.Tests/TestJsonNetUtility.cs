using System.Xml;
using NUnit.Framework;
using UnityEngine;

namespace UGF.JsonNet.Runtime.Tests
{
    public class TestJsonNetUtility
    {
        public class Target
        {
            public int IntValue { get; set; } = 15;
        }

        public class Target2 : Target
        {
            public bool BoolValue { get; set; } = true;
        }

        public class Target3 : Target2
        {
            public float FloatValue { get; set; } = 10.5F;
        }

        [Test]
        public void ToJson()
        {
            var target = new Target3();

            string actual = JsonNetUtility.ToJson(target);
            string expected = Resources.Load<TextAsset>("data0").text;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FromJson()
        {
            string text = Resources.Load<TextAsset>("data1").text;
            var target = JsonNetUtility.FromJson<Target3>(text);

            Assert.AreEqual(1515, target.IntValue);
            Assert.AreEqual(false, target.BoolValue);
            Assert.AreEqual(5.5, target.FloatValue);
        }

        [Test]
        public void Format()
        {
            string compact0 = Resources.Load<TextAsset>("data1").text;
            string readable0 = Resources.Load<TextAsset>("data2").text;

            string readable1 = JsonNetUtility.Format(compact0);
            string compact1 = JsonNetUtility.Format(readable0, false);

            Assert.AreEqual(readable0, readable1);
            Assert.AreEqual(compact0, compact1);
        }
    }
}
