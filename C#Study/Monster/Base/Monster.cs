using C_Study;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class Monster : ICreatureStat
    {
        protected Monster() { }

        public int MaxHP 
        {
            get { return _maxHP; }
            protected set { _maxHP = value; } 
        }

        public int CurrentHP
        {
            get { return _currentHP; }
            protected set { _currentHP = value; }
        }

        public int AttPower 
        {
            get { return _attPower; }
            protected set { _attPower = value; }
        }

        public int DefPower
        {
            get { return _defPower; }
            protected set { _defPower = value; }
        }

        private int _maxHP;
        private int _currentHP;

        private int _attPower;
        private int _defPower;
    }
}
