using MvcStructure.Models;
using MvcStructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStructure.Controllers
{
    public class HomeController : Controller
    {
        DataContext objDataContext = new DataContext();
        public ActionResult Index()
        {
            try
            {
                List<Employee> employee = objDataContext.employees.ToList();
                return View(employee);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(Employee objEmp)
        {
            objDataContext.employees.Add(objEmp);
            objDataContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Edit(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = objDataContext.employees.Find(empId);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee objEmp)
        {
            var data = objDataContext.employees.Find(objEmp.EmpId);
            if (data != null)
            {
                data.Name = objEmp.Name;
                data.Address = objEmp.Address;
                data.Email = objEmp.Email;
                data.MobileNo = objEmp.MobileNo;
            }
            objDataContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public ActionResult Details(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = objDataContext.employees.Find(empId);
            return View(emp);
        }
        public ActionResult Delete(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = objDataContext.employees.Find(empId);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Delete(Employee objEmp)
        {
            var emp = objDataContext.employees.Find(objEmp.EmpId);
            objDataContext.employees.Remove(emp);
            objDataContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}