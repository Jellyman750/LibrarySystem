using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Controller;
using Library.DataAccess;

namespace Library.View
{

    public enum MenuOptionMembers
    {
        Borrow_Books=1,
        Return_Books,
        Exit_System=99
        
    }
    public  class MemberMenu
    {
        private databaseHelper db;
        private viewFunctions view;
        private MainController main;

        public void displayMembersMenu()
        {
            int ans = 0;
            do
            {
                main = new MainController(db, view);
                foreach (MenuOptionAdmin m in Enum.GetValues(typeof(MenuOptionAdmin)))
                {
                    Console.WriteLine($"{(int)m}. {m.ToString().Replace("_", "")} ");
                }

                Console.Write("Please enter in an option: ");
                ans = int.Parse(Console.ReadLine());

                switch ((int)ans)
                {
                    case (int)MenuOptionMembers.Borrow_Books:

                        break;

                    case (int)MenuOptionMembers.Return_Books:
                        main.ReturnBook();
                        break;

                    case (int)MenuOptionMembers.Exit_System:
                        System.Environment.Exit(0);
                        break;
                }
            }
            while (ans != 99);

        }
    }
}
