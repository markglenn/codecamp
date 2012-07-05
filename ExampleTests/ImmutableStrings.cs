using System;
using NUnit.Framework;

namespace ExampleTests
{
    [TestFixture()]
    public class ImmutableStrings
    {
        [Test()]
        public void TestCase ()
        {
            String original = "Hello World!";
            String modified = original.Insert( 6, "There " );

            Assert.AreEqual( "Hello World!", original );
            Assert.AreEqual( "Hello There World!", modified );
        }
    }
}

