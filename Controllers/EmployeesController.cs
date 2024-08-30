using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext Context;

        public EmployeesController(ApplicationDbContext context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            var Employees = Context.Employees.AsNoTracking().ToList();
            return View(Employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            Context.Employees.Add(emp);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditItem(int Id)
        {
            var Employee = Context.Employees.Find(Id);
            return View(Employee);
        }
        public IActionResult Update(Employee Emp)
        {
            var Employee = Context.Employees.Find(Emp.Id);
            Employee.Name=Emp.Name;
            Employee.Email=Emp.Email;
            Employee.Salary=Emp.Salary;
            Employee.Phone=Emp.Phone;
            Employee.Password=Emp.Password;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteItem(int Id)
        {
            var Employee=Context.Employees.Find(Id);
            Context.Employees.Remove(Employee);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        

    }
}
