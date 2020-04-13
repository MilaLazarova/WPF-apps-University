using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        public static List<User> testUsers {
            get {
                ResetTestUserData();
                return  _testUsers;
            }
            set { }
        }

        static public void SetUserActiveTo(String name1, DateTime newDate) {
            foreach (User i in testUsers) {
                if (i.name == name1) {
                    i.ValidTill = newDate;
                    Logger.LogActivity("Промяна на активност на " + name1);
                }
            }
        
        }

        static public void AssignUserRole(String name1, UserRoles role1) {
            foreach (User i in testUsers)
            {
                if (i.name==name1) {
                    i.role =(int)role1;
                    Logger.LogActivity("Промяна на роля на " +name1);
                }
            }
        }
        static private List<User> _testUsers= new List<User>();
        static private void ResetTestUserData() {
            User user1 = new User();
            user1.name = "Georgi";
            user1.pass = "123456";
            user1.role = 4;
            user1.facNum = "1212121";
            user1.Created = DateTime.Now;
            user1.ValidTill = DateTime.MaxValue;
            User user2 = new User();
            user2.name = "Milichka";
            user2.pass = "654321";
            user2.role = 4;
            user2.facNum = "232323";
            user2.Created = DateTime.Now;
            user2.ValidTill = DateTime.MaxValue;
            User user3 = new User();
            user2.name = "Sevastopolis";
            user2.pass = "654321";
            user2.role = 1;
            user2.facNum = "111111";
            user3.Created = DateTime.Now;
            user3.ValidTill = DateTime.MaxValue;
            _testUsers.Add( user1);
            _testUsers.Add(user2);
            _testUsers.Add( user3);
            /* 
            if (_testUser == null)
            {
                _testUser = new User();
                _testUser.name = "Mila";
                _testUser.pass = "1212h";
                _testUser.facNum = "121212";
                _testUser.role = 3;
            }
            */
        }


        public static User IsUserPassCorrect( String name2,  String pass2) {

            foreach (User i in testUsers) {
                if (i.name == name2 && i.pass == pass2) {
                    return i;
                }
                

            }
            return null;

        }

    }
}
