using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Controller;
using Library.DataAccess;

namespace Library.View
{
    public enum MenuOptionAdmin
    {
        View_all_Books=1,
        Insert_A_New_Book,
        Update_A_Book,
        Delete_A_Book,
        View_All_Book_Loans,
        Exit_System=99
    }
    public class AdminMenu
    {
        private databaseHelper db;
        private viewFunctions view;
        private MainController main;

       

       public void displayAdminMenu()
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
                    case (int)MenuOptionAdmin.View_all_Books:

                        main.viewAllBooks();
                        break;

                    case (int)MenuOptionAdmin.Insert_A_New_Book:
                        main.InsertBooks();

                        break;
                    case (int)MenuOptionAdmin.Update_A_Book:
                        main.updateBooks();

                        break;
                    case (int)MenuOptionAdmin.Delete_A_Book:

                        main.DeleteBooks();
                        break;
                    case (int)MenuOptionAdmin.View_All_Book_Loans:

                        main.viewAllLoans();
                        break;

                    case (int)MenuOptionAdmin.Exit_System:
                        System.Environment.Exit(0);
                        break;
                }
            }
            while (ans != 99);

        }
    }
}
