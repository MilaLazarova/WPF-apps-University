using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{

   class Program
    {StringBuilder sb = new StringBuilder(); 
        static void MyErrorMessage(String err)
        {
            LoginValidation.errorText = err;
            Console.WriteLine("!!!!" + err + "!!!!");
        }


        static void IfAdmin()
        {
            Console.WriteLine("Choose: ");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change User Role");
            Console.WriteLine("2: Change User Active time");
            Console.WriteLine("3: Display users list ");
            Console.WriteLine("4: Display log ");
            Console.WriteLine("5: Display current activity ");
            Console.WriteLine("6:Show activity for the previous 2 days");
            String nameCustomer;
            UserRoles newRole;
           DateTime date;


            int choise1 = Convert.ToInt32(Console.ReadLine());
            switch (choise1)
            {
                case 1:
                    Console.WriteLine("Please enter name:");
                    nameCustomer = Console.ReadLine();
                    Console.WriteLine("Enter role");
                    newRole = (UserRoles)Convert.ToInt32(Console.ReadLine()); break;
                    UserData.AssignUserRole(nameCustomer,newRole);
                    break;
                case 2:
                    Console.WriteLine("Please enter name:");
                    nameCustomer = Console.ReadLine();
                    Console.WriteLine("Enter Date");
                     date = DateTime.Parse(Console.ReadLine()); break;
                    UserData.SetUserActiveTo(nameCustomer, date);
                    break;
                case 3: foreach (User i in UserData.testUsers) { Console.WriteLine("Razni danni"); }; break;
                case 4: Logger.ReadFileTest(); break;
                case 5: Logger.GetCurrentSessionActivities(); break;



            }


        }

        public static int ShowActivity(String nick)
        {
            int count=0 ;
            String userLogInfo;
            DateTime timeNow = DateTime.Now;
            DateTime timeThen;
            StreamReader sreader = new StreamReader("test.txt");
            while ((userLogInfo = sreader.ReadLine()) != null) {
                String[] info = userLogInfo.Split(';');
                if (info[0].Equals(nick)) {
                    timeThen = DateTime.Parse(info[1]);
                    if (timeThen >= timeNow.AddDays(-2) && timeThen < timeNow) {
                        count++;
                    }
                }
            }  
            return count;
        }




        static void Main(string[] args)
        {
            /*User x1 = new User() ;
            x1.name = "Mila";

            x1.pass = "1212h";
            x1.facNum = "121212";
            x1.role = 3;
      */
            String name1;
            String pass1;
            Console.WriteLine("Please enter name of the user.");
            name1 = Console.ReadLine();
            Console.WriteLine("Please enter password for the user.");
            pass1 = Console.ReadLine();


            User myUser = null;
            LoginValidation lv1 = new LoginValidation(name1, pass1, MyErrorMessage);
            if (lv1.ValidateUserInput(ref myUser) == true)
            {
                Console.WriteLine("Name is " + myUser.name + " Pass is: " + myUser.pass + " Fac num is: " + myUser.facNum + " Role is: " + myUser.role + " Log Val:" + LoginValidation.currentUserRole +"User Logged times: "+ShowActivity(myUser.name));
                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ANONYMOUS: Console.WriteLine("ANONYMOUS IS MY POWER"); break;
                    case UserRoles.ADMIN: Console.WriteLine("THIS IS A FAKIN ADMIN"); break;
                    case UserRoles.INSPECTOR: Console.WriteLine("I'm an insperktor"); break;
                    case UserRoles.PROFESSOR: Console.WriteLine("I'm a professor"); break;
                    case UserRoles.STUDENT: Console.WriteLine("Nobody cares about me, jsut a stupid student"); break;

                }

                if (LoginValidation.currentUserRole == UserRoles.ADMIN)
                {
                    IfAdmin();


                }
                Console.ReadLine();

            }
        }
    }

}