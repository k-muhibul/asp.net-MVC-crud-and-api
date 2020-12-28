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
    public class StudentService 
    {
        private UnitOfWork unitOfWork;
        public StudentService(UnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

       /* private AppDBContext db = new AppDBContext();*/

      public IEnumerable<Student> GetAllStudent()
        {
            var res = unitOfWork.StudentRepository.GetAll().AsEnumerable();
            return res;
        }

        public Student GetStudent(int id)
        {
            Student student = unitOfWork.StudentRepository.GetById(id);
            /*Student student = db.Students.Find(id);*/
            return student;
        }


        public void DeleteStudent(int id)
        {
            Student student = unitOfWork.StudentRepository.GetById(id);
            unitOfWork.StudentRepository.Delete(student);
            unitOfWork.Save();

        }

        public void UpdateStudent(Student student)
        {
            unitOfWork.StudentRepository.Update(student);
            unitOfWork.Save();
        }


        public void CreateStudent( Student student)
        {
            unitOfWork.StudentRepository.Insert(student);
            unitOfWork.Save();
        }









    }
}
