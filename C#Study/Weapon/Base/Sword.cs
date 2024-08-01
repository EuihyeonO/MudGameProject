using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class Sword : Weapon
    {
        protected Sword()
        {
            WPType = WeaponType.Sword;
            CriticalProb = 0.25f;
        }

        protected float BleedingProb
        {
            get { return _bleedingProb; }
            set { _bleedingProb = value; }
        }

        private float _bleedingProb;
    }
}
