using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Core.ViewModels
{
public class StudentCourseViewModel
    {
        public int CourseId { get; set; }
        public Student student;
        public Course course;
    }
}
