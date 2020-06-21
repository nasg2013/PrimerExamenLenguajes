using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1MVC.Models
{
    public class Nationality
    {
        private int nationalityId;
        private string name;

        public Nationality()
        {
        }

        public Nationality(int nationalityId, string name)
        {
            this.nationalityId = nationalityId;
            this.name = name;
        }

        public int NationalityId { get => nationalityId; set => nationalityId = value; }
        public string Name { get => name; set => name = value; }
    }
}