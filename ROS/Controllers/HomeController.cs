using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ROS.Models;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ROS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateEmployee()
        {
            return View();
        }

        public int AddEmployee(EmployeeModel model)
        {
            using(var context = new ROSEntities())
            {
                Employee emp = new Employee()
                {
                    Name = model.Name,
                    Department = model.Department,
                    Email = model.Email,
                    Address = model.Address,
                };
                context.Employees.Add(emp);
                context.SaveChanges();

                return emp.ID;
            }
        }

        public JsonResult EmployeeList()
        {
            var context = new ROSEntities();
            List<EmployeeModel> emp = context.Employees.Select(x => new EmployeeModel() { 
                       ID = x.ID,
                       Name = x.Name,
                       Address = x.Address,
                       Email = x.Email,
                       Department = x.Department
       
            }).ToList();
            var json = JsonConvert.SerializeObject(emp);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EmployeeData()
        {
            var context = new ROSEntities();
            var item = context.Employees.Select(x => new EmployeeModel()
            {
                ID = x.ID,
                Name = x.Name,
                Address = x.Address,
                Email = x.Email,
                Department = x.Department

            }).ToList();
            return View(item);
        }

        public EmployeeModel GetSpecificEmployee(int id)
        {
            var context = new ROSEntities();
            return context.Employees.Where(x => x.ID == id).Select(x => new EmployeeModel()
            {
                ID = x.ID,
                Name = x.Name,
                Address = x.Address,
                Email = x.Email,
                Department = x.Department
            }).FirstOrDefault();
        }

        public ActionResult viewEmployeeListPage()
        {
            return View();
        }
    }
}