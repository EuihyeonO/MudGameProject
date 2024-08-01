using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class Player : ICreatureStat
    {
        public Player()
        {
            _attPower = 10;
            _defPower = 10;

            _maxHP = 100;
            _currentHP = 100;

            _maxEXP = 100;
            _currentEXP = 0;

            _criticalPower = 1.5f;
            _criticalProb = 0.05f;

            _level = 1;

            _weaponSkilled = 1;

            _money = 1000;

            _inventory = new List<Item>();
        }

        private void LevelUp()
        {
            _currentEXP -= _maxEXP;
            DevFunctions.WriteLineColored("레벨이 상승하였습니다!\n", ConsoleColor.Cyan);

            MaxEXP = (int)(_maxEXP * 1.1f);

            _level++;

            _attPower += 10;
            _defPower += 2;
        }

        public Weapon EquipedWeapon
        {
            get { return _equipedWeapon; }
            set 
            {
                if(_equipedWeapon != null)
                {
                    _attPower -= _equipedWeapon.AttPower;
                    _criticalProb -= _equipedWeapon.CriticalProb;
                }

                _equipedWeapon = value;

                _attPower += _equipedWeapon.AttPower;
                _criticalProb += _equipedWeapon.CriticalProb;
            }
        }

        public int AttPower
        {
            get { return _attPower; }
        }
        public int DefPower
        {
            get { return _defPower; }
        }

        public int Level
        {
            get { return _level; }
        }

        public int WeaponSkilled
        {
            get { return _weaponSkilled; }
        }

        public int MaxHP
        {
            get { return _maxHP; }
        }

        public int CurrentHP
        {
            get { return Math.Max(0, _currentHP); }
            set { _currentHP = value; }
        }

        public int MaxEXP
        {
            get { return _maxEXP; }
            set { _maxEXP = value; }
        }

        public int CurrentEXP
        {
            get { return _currentEXP; }
            set 
            {
                _currentEXP = value;

                if (_currentEXP >= _maxEXP)
                {
                    LevelUp();
                }
            }
        }
        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }

        public float CriticalPower
        {
            get { return _criticalPower; }
        }
        public float CriticalPower_100
        {
            get { return _criticalPower * 100; }
        }

        public float CriticalProb
        {
            get { return _criticalProb; }
            protected set{ _criticalProb = value; }
        }
        public float CriticalProb_100 
        {
            get { return _criticalProb * 100; } 
        }

        public List<Item> Inventory
        {
            get { return _inventory; }
        }

        private Weapon _equipedWeapon;

        private int _attPower;
        private int _defPower;

        private float _criticalPower;
        private float _criticalProb;

        private int _level;
        private int _weaponSkilled;

        
        private int _maxHP;
        private int _currentHP;

        private int _maxEXP;
        private int _currentEXP;

        private int _money;

        List<Item> _inventory;
    }

}
