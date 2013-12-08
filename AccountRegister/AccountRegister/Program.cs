using AccountRegister_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountRegister
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Introduceti parola: ");
            string password = Console.ReadLine();

            int strength = PasswordStrengthMeter.GetPasswordStrength(password);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(string.Format("Puterea parolei este: {0}", strength));

            Console.ReadLine();
        }
    }
}
