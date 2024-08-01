using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class Goblin : Monster
    {
        public Goblin() 
        {
            MaxHP = 100;
            CurrentHP = 100;

            AttPower = 10;
            DefPower = 10;

            Name = "고블린";

            CriticalPower = 1.5f;
            CriticalProb = 0.05f;

            WinEXP = 100;
            WinMoney = 100;

        } 
    }
}
