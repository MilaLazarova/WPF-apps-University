using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfoSystem
{
    public class Student
    {
       public String name, surname, lastname, faculty, specialty;
        public int facNum, uniYear, potok, group;
        public enum Status {finished, inProgress, itnerrupted }

        public Status statusNew;
         public Student(string n, string s, string l, string f, string spec, int facnum1, int year, int potok1, int group1, Status st) {
            name = n;surname = s; lastname = l; faculty = f;specialty = spec;facNum = facnum1; uniYear = year;potok = potok1;group = group1; statusNew=st;
        }

    }
}
