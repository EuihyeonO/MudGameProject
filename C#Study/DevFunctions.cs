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

            if (str.Length > 1)
            {
                return false;
            }

            if (char.IsDigit(str[0]) == false)
            {
                return false;
            }

            return true;
        }
    }
}
