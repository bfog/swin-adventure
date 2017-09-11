using System;
using NUnit.Framework;

namespace Swin_Adventure
{
    [TestFixture]
    public class IdentifiableObjectUnitTest
    {
        [Test]
        public void TestAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });

            Assert.IsTrue(id.AreYou("fred"));
            Assert.IsTrue(id.AreYou("bob"));
        }

        [Test]
        public void TestNotAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });

            Assert.IsFalse(id.AreYou("wilma"));
            Assert.IsFalse(id.AreYou("bobby"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });

            Assert.IsTrue(id.AreYou("FRED"));
            Assert.IsTrue(id.AreYou("bOB"));
        }

        [Test]
        public void TestFirstID()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });

            Assert.AreEqual("fred", id.FirstId);
        }
        [Test]
        public void AddID()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });

            id.AddIdentifier("wilma");

            Assert.IsTrue(id.AreYou("fred"));
            Assert.IsTrue(id.AreYou("bob"));
            Assert.IsTrue(id.AreYou("wilma"));
        }
    }
}
