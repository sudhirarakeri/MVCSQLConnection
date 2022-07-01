using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCSQLConnection.Models;
using System;

namespace MVCSQLConnection.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDal context = new EmployeeDal();
        public IActionResult List()
        {
            ViewBag.EmployeeList = context.GetAllEmployee();
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
            Employee e=new Employee();
            e.Name=form["name"];
            e.Designation = form["designation"];
            e.Salary = Convert.ToDouble(form["salary"]);
            int res = context.Save(e);
            if (res == 1)
            {
                return RedirectToAction("List");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee emp = context.GetEmployeeById(id);
            ViewBag.Name = emp.Name;
            ViewBag.Designation = emp.Designation;
            ViewBag.Salary = emp.Salary;
            ViewBag.Id = emp.Id;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Employee emp = new Employee();
            emp.Name = form["name"];
            emp.Designation = form["designation"];
            emp.Salary = Convert.ToDouble(form["salary"]);
            emp.Id = Convert.ToInt32(form["id"]);
            int res = context.Update(emp);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee emp = context.GetEmployeeById(id);
            ViewBag.Name = emp.Name;
            ViewBag.Designation = emp.Designation;
            ViewBag.Salary = emp.Salary;
            ViewBag.Id = emp.Id;
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
