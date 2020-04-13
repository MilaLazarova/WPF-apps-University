using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        public static UserRoles currentUserRole { get; private set; }
        public static String nickname;
        public static String password;
        public static String errorText;
        public delegate void ActionOnError(string errorMsg);
        public static ActionOnError delError1;
        // currentUserRole = UserRoles.ANONYMOUS;
        public LoginValidation(String name, String pass, ActionOnError actionError) {
            delError1 = actionError;
            nickname = name;
            password = pass;
        }
        public bool ValidateUserInput(ref User u) {
            // u = UserData.testUser;
            
            
            Boolean emptyUserName;
            Boolean emptyPassword;
            
            emptyUserName = nickname.Equals(String.Empty);
            if (emptyUserName == true) {
                delError1("No presence of user name");
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            emptyPassword = password.Equals(String.Empty);
            if (emptyPassword == true)
            {
                delError1("No presence of password");
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            if (nickname.Length < 6)
           {
                delError1( "Nickname is too short.");
                currentUserRole = UserRoles.ANONYMOUS;
                return false;    
            }

            if (password.Length < 6)
            {
                delError1( "Password is too short.");
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
            u = UserData.IsUserPassCorrect(nickname, password);
            currentUserRole = (UserRoles)u.role;

            if (u==null)
            {
                delError1("Invalid User");
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
                
           
            }
            else {
                currentUserRole = (UserRoles)u.role;
                
            }
            Logger.writeAccurancyToFile();
            Logger.LogActivity("Успешен Login");
            return true;

        }
    }
}
