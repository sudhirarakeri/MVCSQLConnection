using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCSQLConnection.Models;

namespace MVCSQLConnection.Controllers
{
    public class EmployeeWithModelController : Controller
    {
        EmployeeDal db=new EmployeeDal();
        // GET: EmployeeWithModelController
        public ActionResult Index()
        {
            var model=db.GetAllEmployee();
            return View(model);
        }

        // GET: EmployeeWithModelController/Details/5
        public ActionResult Details(int id)
        {
            var emp = db.GetEmployeeById(id);
            return View(emp);
        }

        // GET: EmployeeWithModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeWithModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                db.Save(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeWithModelController/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = db.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeWithModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                db.Update(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeWithModelController/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = db.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeWithModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                db.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
