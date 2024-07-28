using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
            get { return _wpType;  }
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

    public class Sword : Weapon
    {
        protected Sword()
        {
            WPType = WeaponType.Sword;
            CriticalProb = 25.0f;
        }

        protected float BleedingProb
        { 
            get { return _bleedingProb; }
            set { _bleedingProb = value; }  
        }

        private float _bleedingProb;
    }

    public class Spear : Weapon
    {
        protected Spear()
        {
            WPType = WeaponType.Spear;
            CriticalProb = 15.0f;
        }

        protected float EvadingProb
        {
            get { return _evadingProb; }
            set { _evadingProb = value; }
        }

        private float _evadingProb;
    }

    public class Hammer : Weapon
    {
        protected Hammer()
        {
            WPType = WeaponType.Hammer;
            CriticalProb = 5.0f;
        }

        protected float StunProb
        {
            get { return _stunProb; }
            set { _stunProb = value; }
        }

        private float _stunProb;
    }

    public class OldSword : Sword
    {
        public OldSword()
        {
            WPName = "오래된 검";
            AttPower = 10;
            BleedingProb = 5.0f;
        }
    }

    public class OldSpear : Spear
    {
        public OldSpear()
        {
            WPName = "오래된 창";
            AttPower = 15;
            EvadingProb = 10.0f;
        }
    }

    public class OldHammer : Hammer
    {
        public OldHammer()
        {
            WPName = "오래된 망치";
            AttPower = 30;
            StunProb = 5.0f;
        }
    }
}
