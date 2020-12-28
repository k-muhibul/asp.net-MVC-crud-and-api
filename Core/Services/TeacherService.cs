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
    public class TeacherService
    {
        private UnitOfWork unitOfWork;
        public TeacherService(UnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        /* private AppDBContext db = new AppDBContext();*/

        public IEnumerable<Teacher> GetAllStudent()
        {
            var res = unitOfWork.TeacherRepository.GetAll().AsEnumerable();
            return res;
        }

        public Teacher GetStudent(int id)
        {
            Teacher teacher = unitOfWork.TeacherRepository.GetById(id);
            /*Student student = db.Students.Find(id);*/
            return teacher;
        }


        public void DeleteStudent(int id)
        {
            Teacher teacher = unitOfWork.TeacherRepository.GetById(id);
            unitOfWork.TeacherRepository.Delete(teacher);
            unitOfWork.Save();

        }

        public void UpdateStudent(Teacher teacher)
        {
            unitOfWork.TeacherRepository.Update(teacher);
            unitOfWork.Save();
        }


        public void CreateStudent(Teacher teacher)
        {
            unitOfWork.TeacherRepository.Insert(teacher);
            unitOfWork.Save();
        }









    }
}
