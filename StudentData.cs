using System;
using UserLogin;
using System.Collections.Generic;
using System.Text;

namespace StudentInfoSystem
{
    class StudentData
    {
        public static Student n1 = new Student("Misho", "Shamara", "Ritnika", "KSI", "Programirane", 12121212, 1, 1, 11, Student.Status.inProgress);

        static private List<Student> _testStudents;
         static public List<Student> testStudents {
        get{
                ResetTestStudentData();
                    return _testStudents;
            }
        }
        static private void ResetTestStudentData() {
            _testStudents = new List<Student>();
            _testStudents.Add(new Student("Georgi", "Shamara", "Ritnika", "KSI", "Programirane", 1212121, 1, 1, 11, Student.Status.inProgress));
        }
        
       
        
    }
}
