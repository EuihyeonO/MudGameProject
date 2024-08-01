using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public interface ICreatureStat
    {
        int AttPower { get; }
        int DefPower { get; }

        float CriticalProb { get;}
        float CriticalProb_100 { get; }
        float CriticalPower { get; }
        float CriticalPower_100 { get; }
    }
}