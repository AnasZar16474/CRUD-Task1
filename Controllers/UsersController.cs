using CRUD.Data;
using CRUD.Migrations;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;


namespace CRUD.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;

        public UsersController(ApplicationDbContext Context)
        {
            context = Context;
        }
        public IActionResult DisplayUsers()
        {
            var Users = context.Users.Where(U => U.IsActive == false).ToList();
            
            
            return View(Users);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction(nameof(SignIn));
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(User user)
        {
            var checkUser = context.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password);
            if (checkUser.Any())
            {
                return RedirectToAction("Index", "Employees");
            }
            ViewBag.Error = "invalid UserName Or Password";
            return View();
        }
        public IActionResult IsActive(Guid UserId)
        {
            var User = context.Users.Find(UserId);
            if(User.IsActive == false)
            {
                User.IsActive=true;
            }
            context.SaveChanges();
            return RedirectToAction(nameof(DisplayUsers));
        }

    }
}
