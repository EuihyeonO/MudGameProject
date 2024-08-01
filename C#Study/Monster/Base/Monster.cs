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
            get { return Math.Max(0, _currentHP); }
            set { _currentHP = value; }
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
        public int WinMoney
        {
            get { return _winMoney; }
            protected set { _winMoney = value; }
        }

        public int WinEXP
        {
            get { return _winEXP; }
            protected set { _winEXP = value; }
        }
        public string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }

        public float CriticalPower
        {
            get { return _criticalPower; }
            protected set { _criticalPower = value; }   
        }
        public float CriticalPower_100
        {
            get { return _criticalPower * 100; }
        }

        public float CriticalProb
        {
            get { return _criticalProb; } 
            protected set { _criticalProb = value;}
        }
        public float CriticalProb_100
        {
            get { return _criticalProb * 100; }
        }

        private int _maxHP;
        private int _currentHP;

        private int _attPower;
        private int _defPower;

        private float _criticalProb;
        private float _criticalPower;

        private string _name;

        private int _winMoney;
        private int _winEXP;
    }
}
