using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.model
{
    public class UserDetails
    {
        int id;
        int UserId;
        string name;
        int age;
        string userEmail;
        string userPassword;
        long userMobile;
        string userStatus;
        string userRole;
        string userAdress;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string UserAdress
        {
            get { return userAdress; }
            set { userAdress = value; }
        }

        public string UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }

        public string UserStatus
        {
            get { return userStatus; }
            set { userStatus = value; }
        }

        public long UserMobile
        {
            get { return userMobile; }
            set { userMobile = value; }
        }

        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }

        public string UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }


        public int UserId1
        {
            get { return UserId; }
            set { UserId = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

       


    }
}
