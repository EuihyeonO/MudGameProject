using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class Item
    {
        protected Item()
        {
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

        public int WeaponSkilled
        {
            get { return _weaponSkilled; }
            protected set { _weaponSkilled = value; }
        }

        public int HealHP
        {
            get { return _healHP; }
            protected set { _healHP = value; }
        }

        public float CriticalPower
        {
            get { return _criticalPower; }
            protected set { _criticalPower = value; }
        }

        public float CriticalProb
        {
            get { return _criticalProb; }
            protected set { _criticalProb = value; }
        }

        public int RemainTurn
        {
            get { return _remainTurn; }
            protected set { _remainTurn = value; }
        }


        private int _attPower;
        private int _defPower;

        private float _criticalPower;
        private float _criticalProb;

        private int _weaponSkilled;

        private int _healHP;
        private int _remainTurn;
    }
    public class Apple : Item
    {
        public Apple()
        {
            HealHP = 50;
        }
    }
}
