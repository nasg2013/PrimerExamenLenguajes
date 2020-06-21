using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1MVC.Models
{
    public class StudentDTO
    {
                    
        private int studentId;
        private string name;
        private int age; 
        private Nationality nationality;
        private Major major;
       

        public StudentDTO()
        {
        }

        public StudentDTO(int studentId, string name, int age, Nationality nationality, Major major)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
            Nationality = nationality;
            Major = major;
        }
        public int StudentId { get => studentId; set => studentId = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public Nationality Nationality { get => nationality; set => nationality = value; }
        public Major Major { get => major; set => major = value; }
    }
}