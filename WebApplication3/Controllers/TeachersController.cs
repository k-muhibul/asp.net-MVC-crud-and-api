using Domain.Models;
using Core.Services;
using WebApplication3.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace WebApplication3.Controllers
{
    public class TeachersController : Controller
    {
        private UnitOfWork unitOfWork;
        private TeacherService teacherService;


        public TeachersController()
        {
            unitOfWork = new UnitOfWork(new AppDBContext());
            teacherService = new TeacherService(unitOfWork);

        }

        // GET: Teachers
        public ActionResult Index()
        {
            var teacher = teacherService.GetAllStudent();

            return View(teacher);



        }



        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            teacherService.CreateStudent(teacher);
            TempData["message"] = "Created Successfully";
            return RedirectToAction("Index");
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int id)
        {
            Teacher teacher = teacherService.GetStudent(id);
            return View(teacher);
        }


        public ActionResult Delete(int id)
        {
            var teacher = teacherService.GetStudent(id);
            return View(teacher);
        }
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {


            teacherService.DeleteStudent(id);
            TempData["message"] = "Deleted Succssesfully";
            return RedirectToAction("Index");



        }

        public ActionResult Edit(int id)
        {
            var teacher = teacherService.GetStudent(id);


            return View(teacher);
        }
        [HttpPost]
        public ActionResult Edit(Teacher teacher)
        {



            teacherService.UpdateStudent(teacher);
            TempData["message"] = "Update Sucssesfully";
            return RedirectToAction("Index");




        }
    }
}
