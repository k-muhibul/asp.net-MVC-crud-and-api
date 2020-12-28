using Domain.Models;
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
    public class CourseService
    {
        private UnitOfWork unitOfWork;
        public CourseService(UnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        /* private AppDBContext db = new AppDBContext();*/

        public IEnumerable<Course> GetAllStudent()
        {
            var res = unitOfWork.CourseRepository.GetAll().AsEnumerable();
            return res;
        }

        public Course GetStudent(int id)
        {
            Course course = unitOfWork.CourseRepository.GetById(id);
            /*Student student = db.Students.Find(id);*/
            return course;
        }


        public void DeleteStudent(int id)
        {
            Course course = unitOfWork.CourseRepository.GetById(id);
            unitOfWork.CourseRepository.Delete(course);
            unitOfWork.Save();

        }

        public void UpdateStudent(Course course)
        {
            unitOfWork.CourseRepository.Update(course);
            unitOfWork.Save();
        }


        public void CreateStudent(Course course)
        {
            unitOfWork.CourseRepository.Insert(course);
            unitOfWork.Save();
        }









    }
}
