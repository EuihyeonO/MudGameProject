using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Study
{
    public class DevFunctions
    {
        public static bool IsNumeric(string str)
        {
            if (string.IsNullOrEmpty(str) == true)
            {
                return false;
            }

            foreach (char curChar in str)
            {
                if (char.IsDigit(curChar) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
