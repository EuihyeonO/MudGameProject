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
        } 
    }
}
