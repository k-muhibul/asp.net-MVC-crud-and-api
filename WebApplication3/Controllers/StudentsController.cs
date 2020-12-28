using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Services;
using Core.ViewModels;
using Domain.Models;
using WebApplication3.Domain.Repositories;

namespace WebApplication3.Controllers
{
    public class StudentsController : Controller
    {
        private UnitOfWork unitOfWork;
        private StudentService studentService;
        private CourseService courseService;
        private StudentCourseService studentcourseService;


        public StudentsController()
        {
            unitOfWork = new UnitOfWork(new AppDBContext());
            studentService = new StudentService(unitOfWork);
            courseService = new CourseService(unitOfWork);
            studentcourseService = new StudentCourseService(unitOfWork);

        }

        // GET: Students
        public ActionResult Index()
        {
            var student = studentService.GetAllStudent();

            return View(student);
        }

        public ActionResult Assign(int id)
        {
            var student = studentService.GetStudent(id);

            var courses = courseService.GetAllStudent();
            ViewBag.courses = new SelectList(courses, "CourseId", "CourseName");
         
            StudentCourseViewModel studentCourseVM = new StudentCourseViewModel();
            studentCourseVM.student = student;
            
            return View(studentCourseVM);
        }
        [HttpPost]
        public ActionResult AssignConfirm(int courseId, int id)
        {
            Student student = studentService.GetStudent(id);
            Course course = courseService.GetStudent(courseId);
            StudentCourse studentCourse = new StudentCourse();
            studentCourse.Course = course;
            studentCourse.student = student;
            studentCourse.CourseId = course.CourseId;
            studentCourse.StudentID = student.ID;


            studentcourseService.CreateStudent(studentCourse);
            TempData["message"] = "Deleted Succssesfully";
            return RedirectToAction("Index");



        }


        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            studentService.CreateStudent(student);
            TempData["message"] = "Created Successfully";
            return RedirectToAction("Index");
        }

      /*  public ActionResult ViewCourse(int id)
        {
            var res = studentcourseService.showCourse(id);

            return View(res);
        }*/

        public ActionResult Details(int id)
        {
            Student student = studentService.GetStudent(id);
            return View(student);
        }
        public ActionResult showCourses(int id)
        {
            Student student = studentService.GetStudent(id);
            StudentCourse studentCourse = studentcourseService.GetStudent(id);
            StudentCourseViewModel studentCourseVM = new StudentCourseViewModel();
            studentCourseVM.course = studentCourse.Course;
            studentCourseVM.student = student;
            studentCourseVM.CourseId = studentCourse.CourseId;
            return View(studentCourseVM);
        }




        public ActionResult Delete(int id)
        {
            var student = studentService.GetStudent(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {


            studentService.DeleteStudent(id);
            TempData["message"] = "Deleted Succssesfully";
            return RedirectToAction("Index");



        }

        public ActionResult Edit(int id)
        {
            var student = studentService.GetStudent(id);


            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {



            studentService.UpdateStudent(student);
            TempData["message"] = "Update Sucssesfully";
            return RedirectToAction("Index");




        }
    }
}