using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class Apple : Item
    {
        public Apple()
        {
            HealHP = 50;
            RemainTurn = 1;

            Name = "사과";
        }
    }
}
