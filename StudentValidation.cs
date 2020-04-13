using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        
        public  static Student GetStudentDataByUser(UserLogin.User user1) {
            if (user1.facNum.Equals(string.Empty)) {
              //  Console.WriteLine("ERROR:This user has no faculty number.");
                throw new Exception("ERROR:This user has no faculty number.");
            }
            foreach(Student st in StudentData.testStudents) {
                if (st.facNum.ToString().Equals(user1.facNum) )
                {
                    return st;
                }
            }
            throw new Exception("There is no student assigned to this user");
        }




    }
}
