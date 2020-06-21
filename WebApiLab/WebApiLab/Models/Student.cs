using System;
using System.Collections.Generic;

namespace WebApiLab.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string NationalityName { get; set; }
        public string MajorName { get; set; }
        public int? Nationality { get; set; }
        public int? Major { get; set; }
        public string Seniority { get; set; }
        public string Interests { get; set; }
        public string EntryDate { get; set; }

        public virtual Major MajorNavigation { get; set; }
        public virtual Nationality NationalityNavigation { get; set; }
    }
}
