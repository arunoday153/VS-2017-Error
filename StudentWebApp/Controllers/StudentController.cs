using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentWebApp.DAL;
using StudentWebApp.Models;


namespace StudentWebApp.Controllers
{
    public class StudentController : Controller
    {
        employeedbContext Conn = new employeedbContext();
        // GET: Student
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Create(Models.EmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
                var record = Conn.Employees.SingleOrDefault(a => a.ID == emp.ID);
                if (record == null)
                {
                    DAL.Employee empdb = new DAL.Employee();
                    empdb.ID = emp.ID;
                    empdb.Name = emp.Name;
                    empdb.Gender = emp.Gender;
                    empdb.Salary = emp.Salary;
                    empdb.DepartmentID = emp.DepartmentID;

                    Conn.Employees.Add(empdb);
                    Conn.SaveChanges();
                }
                else
                {
                    record.Name = emp.Name;
                    record.Gender = emp.Gender;
                    record.Salary = emp.Salary;
                    record.DepartmentID = emp.DepartmentID;
                    Conn.SaveChanges();

                }

            }
            return View("Index");

        }

        public ActionResult Delete(Models.EmployeeModel emp)
        {
            var result = Conn.Employees.SingleOrDefault(a => a.ID == emp.ID);
            Conn.Employees.Remove(result);
            Conn.SaveChanges();

            return View("Index");
                
        }


        public JsonResult GetAllRecords()
        {
            List<EmployeeModel> emplist = new List<EmployeeModel>();
            var res = Conn.Employees.ToList();

            foreach (var result in res)
            {
                var ListItem = new EmployeeModel();
                ListItem.ID = result.ID;
                ListItem.Name = result.Name;
                ListItem.Gender = result.Gender;
                ListItem.Salary = result.Salary;
                ListItem.DepartmentID = result.DepartmentID;
                ListItem.Department = Conn.Departments.Where(a => a.ID == ListItem.DepartmentID).SingleOrDefault().Department1;

                emplist.Add(ListItem);
            }
            return Json(emplist, JsonRequestBehavior.AllowGet);
        }

    }
}