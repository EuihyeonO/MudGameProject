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
        public static int GetCalculatedDamage(ICreatureStat attacking, ICreatureStat attacked)
        {
            Random random = new Random();

            int MinAtt = (int)(attacking.AttPower * 0.9f);
            int MaxAtt = (int)(attacking.AttPower * 1.1f);

            int Att = random.Next(MinAtt, MaxAtt);
            int Def = attacked.DefPower;

            float DefRate = Def / 100.0f;
            DefRate = 1.0f - DefRate;

            return (int)(Att * DefRate);
        }

        public static bool isCritical(ICreatureStat attacking)
        {
            Random random = new Random();
            int randomValue = random.Next(0, 100);

            if (randomValue <= attacking.CriticalProb_100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

