﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorld
{
    public class Ogre : ArmedCreature
    {
        public Ogre(string name, uint maxHealth, uint basicDamage)
            : base(name, maxHealth, basicDamage)
        {
        }
    }
}
