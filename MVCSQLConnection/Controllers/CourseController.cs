using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCSQLConnection.Models;
using System;

namespace MVCSQLConnection.Controllers
{
    public class CourseController : Controller
    {
        CourseDal context = new CourseDal();
        public IActionResult List()
        {
            ViewBag.CourseList = context.GetAllCourse();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
            Course c = new Course();
            c.Name = form["name"];
            c.Fees = Convert.ToInt32(form["fees"]);
            int res = context.Save(c);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course c = context.GetCourseById(id);
            ViewBag.Name = c.Name;
            ViewBag.Fees = c.Fees;
            ViewBag.Id = c.Id;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Course c = new Course();
            c.Name = form["name"];
            c.Fees = Convert.ToInt32(form["fees"]);
            c.Id = Convert.ToInt32(form["id"]);
            int res = context.Update(c);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Course c = context.GetCourseById(id);
            ViewBag.Name = c.Name;
            ViewBag.Fees = c.Fees;
            ViewBag.Id = c.Id;
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]

        public IActionResult DeleteConfirm(int id)
        {
            int res = context.Delete(id);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
    }
}
