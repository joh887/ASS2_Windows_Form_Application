using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assessment2
{
    class CLogin
    {
        List<CUserInfo> users = new List<CUserInfo>();
        public CUserInfo currentUser = null;
        string path = ".\\Login.txt";

        public static CLogin cLogInfo = null;
        public static CLogin GetInstance() // Singleton Pattern
        {
            if (cLogInfo == null) cLogInfo = new CLogin();
            return cLogInfo;
        }

        public CLogin()
        {

        }

        public List<CUserInfo> Users
        {
            get{ return users; }
        }

        public void LoadUsers() //Load Login.txt file to program
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] userInfo = line.Split(',');
                        users.Add(new CUserInfo(userInfo[0], userInfo[1],
                                        Convert.ToInt16(userInfo[2]), userInfo[3], userInfo[4], Convert.ToDateTime(userInfo[5]))); //datatype
                    }
                }
            }

            catch
            {
                MessageBox.Show("The Login.txt is currently empty. Please add new User");
            }
        }
        public void saveOneUser() //Add one user to the txt File
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (CUserInfo userInfo in users)
                {
                    string strLine = string.Format("{0},{1},{2},{3},{4},{5}", userInfo.Username, userInfo.Password,
                                    userInfo.UserType, userInfo.FirstName, userInfo.LastName, userInfo.Birthday);
                    sw.WriteLine(strLine);
                }

            }
        }
        public void SaveUsers() //Add all user to the txt File
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                foreach (CUserInfo userInfo in users)
                {
                    string strLine = string.Format("{0},{1},{2},{3},{4},{5}", userInfo.Username, userInfo.Password , 
                                    userInfo.UserType, userInfo.FirstName, userInfo.LastName, userInfo.Birthday);
                    sw.WriteLine(strLine);
                }

            }

        }
        //add User in the program
        public void AddUser(string user_name, string password, int user_type, string firstname, string lastname, DateTime birthday)
        {
            CUserInfo user = new CUserInfo(user_name, password, user_type, firstname, lastname, birthday);
            users.Add(user);
        }
        
        //Get whether the user is edit user, view user, or unvalid user.
        public int GetUserType(string username, string password)
        {
            foreach(CUserInfo user in users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    currentUser = user;
                    return user.UserType;
                }
            }
            return 0; // unvalid userID or Password
        }
    }
}
