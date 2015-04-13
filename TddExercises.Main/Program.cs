using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Managers;

namespace TddExercises.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Your register is for...");
            Console.Write(string.Format("Email: {0}; Password: {1}.", email, password));

            //new AccountManager()

            Console.ReadKey();
        }
    }
}
