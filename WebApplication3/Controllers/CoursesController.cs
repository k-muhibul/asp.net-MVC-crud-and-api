using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Services;
using Domain.Models;
using WebApplication3.Domain.Repositories;

namespace WebApplication3.Controllers
{
    public class CoursesController : Controller
    {
        private UnitOfWork unitOfWork;
        private CourseService courseService;


        public CoursesController()
        {
            unitOfWork = new UnitOfWork(new AppDBContext());
            courseService = new CourseService(unitOfWork);

        }

        // GET: Students
        public ActionResult Index()
        {
            var courses = courseService.GetAllStudent();

            return View(courses);
        }
     
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            courseService.CreateStudent(course);
            TempData["message"] = "Created Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Course course = courseService.GetStudent(id);
            return View(course);
        }


        public ActionResult Delete(int id)
        {
            var student = courseService.GetStudent(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {


            courseService.DeleteStudent(id);
            TempData["message"] = "Deleted Succssesfully";
            return RedirectToAction("Index");



        }

        public ActionResult Edit(int id)
        {
            var student = courseService.GetStudent(id);


            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Course student)
        {



            courseService.UpdateStudent(student);
            TempData["message"] = "Update Sucssesfully";
            return RedirectToAction("Index");




        }
    }
}