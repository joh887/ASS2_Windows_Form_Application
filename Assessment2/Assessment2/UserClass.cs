using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class CUserInfo
    {
        private string username;
        private string password;
        private int userType;
        private string firstname;
        private string lastname;
        private DateTime birthday;

        public CUserInfo(string username, string password, int userType,
            string firstname, string lastname, DateTime birthday)
        {
            this.username = username;
            this.password = password;
            this.userType = userType;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthday = birthday;
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public int UserType
        {
            get { return userType; }
            set { userType = value; }
        }
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

    }
}
