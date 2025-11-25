using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class members
    {

        private int memberId;
        private string username;
        private string passwordHash;
        private string role;

        public int MemberId { get => memberId; set => memberId = value; }
        public string Username { get => username; set => username = value; }
        public string PasswordHash { get => passwordHash; set => passwordHash = value; }
        public string Role { get => role; set => role = value; }

        public members(int memeberId_,string username_,string passwordHash_,string role_)
        {
            this.memberId = memeberId_;
            this.username = username_;
            this.passwordHash = passwordHash_;
            this.role = role_;
        }

        public string toString()
        {
            return $"Member ID: {MemberId}, Username: {Username}, Password Hash: {PasswordHash}, Role: {Role}";
        }
    }
}
