using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class Logger
    {
        static StringBuilder sb = new StringBuilder();
        static private List<string> currentSessionActivities = new List<string>();
        static public void LogActivity(string activity) {
            string activityLine = DateTime.Now + ";"
    + LoginValidation.nickname + ";"
    + LoginValidation.currentUserRole + ";"
    + activity;
            currentSessionActivities.Add(activityLine);




        }
        static public void ReadFromFileFIrst()
        {
            if (File.Exists("test.txt") == true)
            {
                string s = Console.ReadLine();
                File.AppendAllText("test.txt", s);
            }
        }
        static public void ReadFileTest()
        {
            StreamReader sr = new
    StreamReader("test.txt");
            string line = sr.ReadLine();
            Console.WriteLine(line);
            line = sr.ReadLine();
            Console.WriteLine(line);
            line = sr.ReadLine();
            Console.WriteLine(line);
            sr.Close();

        }

        static public void GetCurrentSessionActivities()
        {
            foreach (var a in currentSessionActivities)
            {
                sb.AppendLine(a);
            }
            Console.WriteLine(sb);
        }



        public static void writeAccurancyToFile() {
            StreamWriter sr = new
   StreamWriter("test.txt", append: true);
            string latestActivity =  LoginValidation.nickname + ";"
        + DateTime.Now ;

            if (File.Exists("test.txt") == true)
            {
               

                sr.WriteLine(latestActivity);
                sr.Close();
            }


        }


       /* public static void ShowActivity() {
            String readThis;
            List<String> whatiswritten = new List<string>();
            Console.WriteLine("Enter name");
            StreamReader sreader = new StreamReader("test.txt");
            readThis = sreader.ReadToEnd();
          

            for (int i = 0; i < whatiswritten.split; i++) { 
              whatiswritten = readThis.Split(';').ToList() ;
            
            }
            }*/

            
            

        
        }


    }


    

    