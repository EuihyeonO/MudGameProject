using C_Study;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class GameFunctions
    {
        public static int GetFinalAttPower(ICreatureStat attacking, ICreatureStat attacked)
        {
            int Att = attacking.AttPower;
            int Def = attacked.DefPower;
    
            float DefRate = Def / 100.0f;
            DefRate = 1.0f - DefRate;
    
            return (int)(Att * DefRate);
        }
    }
}

