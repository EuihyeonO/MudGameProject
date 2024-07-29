using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class Player
    {
        public Player()
        {
            _attPower = 10;
            _defPower = 10;

            _maxHP = 100;
            _currentHP = 100;

            _maxEXP = 100;
            _currentEXP = 0;

            _criticalPower = 150.0f;
            _criticalProb = 5.0f;

            _level = 1;
            _statPoint = 0;

            _weaponSkilled = 1;

            _money = 0;

            _inventory = new List<Item>();
        }

        public Weapon EquipedWeapon
        {
            get { return _equipedWeapon; }
            set { _equipedWeapon = value; }
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

        public int StatPoint
        {
            get { return _statPoint; }
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
            get { return _currentHP; }
        }

        public int MaxEXP
        {
            get { return _maxEXP; }
        }

        public int CurrentEXP
        {
            get { return _currentEXP; }
        }
        public int Money
        {
            get { return _money; }
        }

        public float CriticalPower
        {
            get { return _criticalPower; }
        }

        public float CriticalProb
        {
            get { return _criticalProb; }
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
        private int _statPoint;
        private int _weaponSkilled;

        
        private int _maxHP;
        private int _currentHP;

        private int _maxEXP;
        private int _currentEXP;

        private int _money;

        List<Item> _inventory;
    }

}
