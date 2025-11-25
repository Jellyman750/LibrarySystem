using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class UserLogin
    {

       public void DisplayMenu()
        {
            Console.WriteLine("WELCOME to the Library system");
            Console.WriteLine("================================\n");

            Console.WriteLine("Please enter in your username");
            string username = Console.ReadLine();

            Console.WriteLine("Please enter in your password");
            string password = Console.ReadLine();

        }
    }
}
