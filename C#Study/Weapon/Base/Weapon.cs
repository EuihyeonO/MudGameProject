using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public enum WeaponType
    {
        None,
        Sword,
        Spear,
        Hammer,
    }

    public class Weapon
    {
        protected Weapon()
        {

        }
        public WeaponType WPType
        {
            get { return _wpType; }
            protected set { _wpType = value; }
        }

        public string WPName
        {
            get { return _wpName; }
            protected set { _wpName = value; }
        }
        public int AttPower
        {
            get { return _attPower; }
            protected set { _attPower = value; }
        }
        public float CriticalProb
        {
            get { return _criticalProb; }
            protected set { _criticalProb = value; }
        }

        private int _attPower;
        private float _criticalProb;

        private string _wpName;
        private WeaponType _wpType;
    }
}
