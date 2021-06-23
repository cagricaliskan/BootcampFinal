using BootcampFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BootcampFinal.Controllers
{
    public class AccountController : Controller
    {
        private readonly ModelContext _db;

        public AccountController(ModelContext db)
        {
            _db = db;
        }



        public IActionResult Index(int page = 1, string search = "")
        {
            var users = _db.Users.Where(x => x.UserRole == UserRole.Resident);

            if(search != "")
            {
                users = users.Where(x => x.Name.Contains(search) || x.LastName.Contains(search));

                ViewBag.search = search;
                ViewBag.searhCount = users.Count();
            }

            users = users.OrderByDescending(n => n.Id);
            ViewBag.page = page;

            return View(users.ToPagedList(page,10));
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
           
            if( user != null)
            {
                _db.Add(user);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
