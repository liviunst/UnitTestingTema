using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountRegister_Core
{
    public static class PasswordStrengthMeter
    {
        public static int GetPasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return 0;

            int result = 0;

            //+1 for length
            if (Math.Max(password.Length, 7) > 7)
                result += 1;

            //+1 for a number
            if (System.Text.RegularExpressions.Regex.Match(password, "[0-9]").Success)
                result += 1;

            //+1 for a special char
            if(System.Text.RegularExpressions.Regex.Match(password,
                "[\\!\\@\\#\\$\\%\\^\\&\\*\\(\\)\\{\\}\\[\\]\\:\\'\\;\\\"\\/\\?\\.\\>\\,\\<]").Success)
            {
                result += 1;
            }

            //+1 for a lower case letter
            if (System.Text.RegularExpressions.Regex.Match(password, "[a-z]").Success)
                result += 1;

            //+1 for a upper case letter
            if (System.Text.RegularExpressions.Regex.Match(password, "[A-Z]").Success)
                result += 1;

            return result;
        }
    }
}
