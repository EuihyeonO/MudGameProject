using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class CriticalProbElixir : Item
    {
        public CriticalProbElixir()
        {
            CriticalProb = 50;
            RemainTurn = 1;

            Name = "필살의 영약";
        }
    }
}
