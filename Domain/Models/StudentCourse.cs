using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class StudentCourse
    {
        [Key]
        [Column(Order =1)]
        public int StudentID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CourseId { get; set; }
        public virtual Student student { get; set; }
        public virtual Course Course { get; set; }
    }
}
