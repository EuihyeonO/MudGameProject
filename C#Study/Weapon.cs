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

        protected WeaponType WPType
        {
            get { return _wpType;  }
            set { _wpType = value; }
        }

        protected string WPName
        {
            get { return _wpName; }
            set { _wpName = value; }
        }
        protected int AttPower
        {
            get { return _attPower; }
            set { _attPower = value; }
        }
        protected float BonusAttackProb
        {
            get { return _bonusAttackprob; }
            set { _bonusAttackprob = value; }
        }

        private int _attPower;
        private float _bonusAttackprob;

        private string _wpName;
        private WeaponType _wpType;
    }

    public class Sword : Weapon
    {
        protected Sword()
        {
            WPType = WeaponType.Sword;
            BonusAttackProb = 25.0f;
        }
    }

    public class Spear : Weapon
    {
        protected Spear()
        {
            WPType = WeaponType.Spear;
            BonusAttackProb = 15.0f;
        }
    }

    public class Hammer : Weapon
    {
        protected Hammer()
        {
            WPType = WeaponType.Hammer;
            BonusAttackProb = 5.0f;
        }
    }

    public class OldSword : Sword
    {
        public OldSword()
        {
            WPName = "오래된 검";
            AttPower = 10;
        }
    }

    public class OldSpear : Spear
    {
        public OldSpear()
        {
            WPType = WeaponType.Spear;
            WPName = "오래된 창";
            AttPower = 15;
        }
    }

    public class OldHammer : Hammer
    {
        public OldHammer()
        {
            WPType = WeaponType.Hammer;
            WPName = "오래된 망치";
            AttPower = 30;
        }
    }
}
