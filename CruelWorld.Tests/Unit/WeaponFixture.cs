using System;
using NUnit.Framework;

namespace CruelWorld.Tests.Unit
{
    [TestFixture]
    public class WeaponFixture
    {
        [TestCase(null)]
        [TestCase("")]
        public void Constructor_NameIsNullOrEmpty_ThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Weapon(name, 50));
        }
    }
}