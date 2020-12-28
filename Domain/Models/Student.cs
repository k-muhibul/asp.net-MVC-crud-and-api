using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace Domain.Models
{
    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

      
    }

 
}