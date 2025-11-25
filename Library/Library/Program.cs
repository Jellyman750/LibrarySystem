using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Controller;
using Library.DataAccess;
using Library.Model;
using Library.View;

namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            databaseHelper db = new databaseHelper();// db.testConnection();
            authenticationController auth = new authenticationController(db);



            UserLogin us = new UserLogin();

            Console.WriteLine("WELCOME to the Library system");
            Console.WriteLine("================================\n");

            Console.WriteLine("Please enter in your username");
            string username = Console.ReadLine();

            Console.WriteLine("Please enter in your password");
            string password = Console.ReadLine();

          members currectuser=  auth.login(username, password);

            if (currectuser.Username == username)
            {


                Console.WriteLine("Logged in sucessfully");
            if (currectuser.Role == "Admin")
            {
                AdminMenu adminmenu = new AdminMenu();
                adminmenu.displayAdminMenu();
            }
            else if (currectuser.Role == "Member")
            {
                MemberMenu memMenu = new MemberMenu();
                memMenu.displayMembersMenu();
            }

             }

            else if(currectuser.Username!=username)
            {
                Console.WriteLine("Login Failed,The user does not exist:");
            }


           

        }
    }
}
