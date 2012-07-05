using System;
using NUnit.Framework;
using Example;

namespace ExampleTests
{
    [TestFixture]
    public class PrimeTests
    {
        [Test]
        public void IsPrime_IsTrueForSmallValues( )
        {
            Assert.IsTrue( Prime.IsPrime( 2 ) );
            Assert.IsTrue( Prime.IsPrime( 3 ) );
            Assert.IsTrue( Prime.IsPrime( 5 ) );
            Assert.IsTrue( Prime.IsPrime( 7 ) );
        }

        [Test]
        public void IsPrime_IsFalseForSmallNonPrimes( )
        {
            Assert.IsFalse( Prime.IsPrime( 0 ) );
            Assert.IsFalse( Prime.IsPrime( 1 ) );
            Assert.IsFalse( Prime.IsPrime( 4 ) );
            Assert.IsFalse( Prime.IsPrime( 6 ) );
            Assert.IsFalse( Prime.IsPrime( 8 ) );
            Assert.IsFalse( Prime.IsPrime( 9 ) );
        }

        [Test]
        public void IsPrime_FalseForLargeNonPrime( )
        {
            Assert.IsFalse( Prime.IsPrime( 3447 ) );
        }

        [Test]
        public void IsPrime_TrueForLargePrime( )
        {
            Assert.IsTrue( Prime.IsPrime( 9876103 ) );
        }
    }
}

