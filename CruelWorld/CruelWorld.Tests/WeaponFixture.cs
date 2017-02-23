using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace CruelWorld.Tests
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
