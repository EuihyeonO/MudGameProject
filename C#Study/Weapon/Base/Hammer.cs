using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class Hammer : Weapon
    {
        protected Hammer()
        {
            WPType = WeaponType.Hammer;
            CriticalProb = 0.05f;
        }

        protected float StunProb
        {
            get { return _stunProb; }
            set { _stunProb = value; }
        }

        private float _stunProb;
    }
}
