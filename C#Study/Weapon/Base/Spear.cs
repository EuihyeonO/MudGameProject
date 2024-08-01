using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class Spear : Weapon
    {
        protected Spear()
        {
            WPType = WeaponType.Spear;
            CriticalProb = 0.15f;
        }

        protected float EvadingProb
        {
            get { return _evadingProb; }
            set { _evadingProb = value; }
        }

        private float _evadingProb;
    }
}
