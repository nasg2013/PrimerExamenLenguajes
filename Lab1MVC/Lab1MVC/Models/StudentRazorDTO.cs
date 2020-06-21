using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1MVC.Models
{
    public class StudentRazorDTO
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Seniority { get; set; }
        public string EntryDate { get; set; }
        public string Interests { get; set; }
        public string NationalityName { get; set; }
        public string MajorName { get; set; }
        public int NationalityId { get; set; }
        public int MajorId { get; set; }
    }
}