using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public enum ItemName
    {
        사과,
        배,
        필살의영약,
    }

    public class Item
    {
        public static bool isCanBuy(Player player, ItemName itemName)
        {
            switch(itemName)
            {
                case ItemName.사과:
                    return (player.Money >= 30);
                case ItemName.배:
                    return (player.Money >= 50);
                case ItemName.필살의영약:
                    return (player.Money >= 200);
            }

            return false;
        }

        public static void BuyItem(Player player, ItemName itemName)
        {
            switch (itemName)
            {
                case ItemName.사과:
                    player.Inventory.Add(new Apple());
                    player.Money -= 30;
                    break;
                case ItemName.배:
                    player.Inventory.Add(new Pear());
                    player.Money -= 50;
                    break;
                case ItemName.필살의영약:
                    player.Inventory.Add(new CriticalProbElixir());
                    player.Money -= 200;
                    break;
            }
        }

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
        public string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }

        private int _attPower;
        private int _defPower;

        private float _criticalPower;
        private float _criticalProb;

        private int _weaponSkilled;

        private int _healHP;
        private int _remainTurn;

        private string _name;
    }
}
