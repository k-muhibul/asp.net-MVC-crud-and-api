using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Domain.Repositories;
using Domain.Models;
using Core.Services;
using Core.ViewModels;
using System.Web.Http.Cors;

namespace WebApplication3.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentWebApiController : ApiController
    {
        private UnitOfWork unitofwork;
        private StudentService studentService;
        private StudentCourseService studentCourseService;


        public StudentWebApiController()
        {
            unitofwork = new UnitOfWork(new AppDBContext());
            studentService = new StudentService(unitofwork);
            studentCourseService = new StudentCourseService(unitofwork);
        }
        [HttpGet]
        [Route("api/getallstudent/")]
        public IHttpActionResult Get()
        {
            List<StudentViewModel> st = new List<StudentViewModel>();

            var student = (from s in studentService.GetAllStudent()
                           select new StudentViewModel
                           { ID = s.ID, Name = s.Name, Email = s.Email, Phone = s.Phone }
            ).ToList();

            return Json(student);

        }
        [Route("api/getallstudent/{id}")]
        public IHttpActionResult Get(int id)
        {

            var student = studentService.GetStudent(id);
            StudentViewModel sVM = new StudentViewModel();
            sVM.ID = student.ID;
            sVM.Name = student.Name;
            sVM.Email = student.Email;
            sVM.Phone = student.Phone;


            return Json(sVM);
        }
        [Route("api/createstudent")]
        [HttpPost]
        public HttpResponseMessage Create(StudentViewModel student)
        {
            try
            {
                Student s = new Student();
               
                s.Name = student.Name;
                s.Phone = student.Phone;
                s.Email = student.Email;
                studentService.CreateStudent(s);
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.Created);
                return responseMessage;
            }
            catch (Exception e)
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return responseMessage;

            }
        }

        [Route("api/updatestudent")]
        [HttpPut]
        public HttpResponseMessage Update(StudentViewModel student)
        {
            try
            {
                Student s = new Student();
                s.ID = student.ID;

                s.Name = student.Name;
                s.Phone = student.Phone;
                s.Email = student.Email;
                studentService.UpdateStudent(s);
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                return responseMessage;
            }
            catch (Exception e)
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return responseMessage;

            }
        }





        [HttpDelete]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/deletestudent/{id}")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            Student student = unitofwork.StudentRepository.GetById(id);
            unitofwork.StudentRepository.Delete(student);
            unitofwork.Save();

            
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            return response;
        }



        [HttpGet]
        [Route("api/studentcourse/{id}")]
        public IHttpActionResult GetCourse(int id)
        {
            List<Course> courses = new List<Course>();
            
            var showCourse=studentCourseService.showCourse(id);
            
         

            return Json(showCourse);

        }
    }
}
