using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
   public class studentCourseApiViewModel
    {
        public int studentId { get; set; }
        List<Course> courses { get; set; }
    }
}
