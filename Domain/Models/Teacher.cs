using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Domain.Models
{
    public class Teacher

    {
        
        public int ID { get; set; }
        public int Faculty_id { get; set; }
        public string Department { get; set; }
        public DateTime Joining_date { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

    }

   
    
}