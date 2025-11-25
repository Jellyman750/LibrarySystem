using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Library.DataAccess;
using Library.Model;

namespace Library.Controller
{
    public class authenticationController
    {


        private databaseHelper db;


        public authenticationController(databaseHelper db_)
        {
            this.db = db_;
        }

        public string hashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytePassword = Encoding.UTF8.GetBytes(password);

                byte[] hashPassword = sha256.ComputeHash(bytePassword);

                StringBuilder builder = new StringBuilder();
                foreach(byte b in hashPassword)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public members login(string username,string password)
        {
            members m = db.getMemberByUsername(username);

            if (m.Username == null)
            {
                Console.WriteLine("The member does not exist");
                return null;
            }
            else
            {
                string hpassword = hashPassword(password);
                if (hpassword == m.PasswordHash)
                {
                    return m;
                }
            }
            return null;
        }
    }
}
