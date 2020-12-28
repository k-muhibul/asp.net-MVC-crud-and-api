using Domain.Models;
using Core.ViewModels;
using WebApplication3.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;


namespace Core.Services
{
    public class StudentCourseService
    {
        private UnitOfWork unitOfWork;
        private ShowStudentCourseViewModel showStudent;
        public StudentCourseService(UnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        /* private AppDBContext db = new AppDBContext();*/

        public IEnumerable<StudentCourse> GetAllStudent()
        {
            var res = unitOfWork.StudentCourseRepository.GetAll().AsEnumerable();
            return res;
        }

        public StudentCourse GetStudent(int id)
        {
            StudentCourse student = unitOfWork.StudentCourseRepository.GetById(id);
            /*Student student = db.Students.Find(id);*/
            return student;
        }


        public void DeleteStudent(int id)
        {
            StudentCourse student = unitOfWork.StudentCourseRepository.GetById(id);
            unitOfWork.StudentCourseRepository.Delete(student);
            unitOfWork.Save();

        }

        public void UpdateStudent(StudentCourse student)
        {
            unitOfWork.StudentCourseRepository.Update(student);
            unitOfWork.Save();
        }


        public void CreateStudent(StudentCourse student)
        {
            unitOfWork.StudentCourseRepository.Insert(student);
            unitOfWork.Save();
        }

        public List<ShowStudentCourseViewModel> showCourse(int id)
        {
            // List<Course> courses = new List<Course>();

            var studentCourse = (from s in unitOfWork.StudentCourseRepository.GetAll()
                                 join c in unitOfWork.CourseRepository.GetAll() on s.CourseId equals c.CourseId
                                 where s.StudentID == id
                                 select new ShowStudentCourseViewModel
                                 {
                                     
                                     studentid = s.StudentID,
                                     courseName=c.CourseName
                                     
                                     




                                 }).ToList();
            return studentCourse;

        }












    }
}
