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


        public JsonResult GetUser(int id)
        {
            User u = _db.Users.Select(x => new User { Id = x.Id, Email = x.Email, LastName = x.LastName, Name = x.Name, PhoneNumber = x.PhoneNumber, TCKN = x.TCKN, Vehicles = x.Vehicles }).FirstOrDefault(n => n.Id == id);
            return Json(u);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            User u = _db.Users.FirstOrDefault(x => x.Id == user.Id);
            if(u != null)
            {
                u.Name = user.Name;
                u.LastName = user.LastName;
                u.PhoneNumber = user.LastName;
                u.PhoneNumber = user.PhoneNumber;
                u.TCKN = user.TCKN;
                u.Vehicles = user.Vehicles;

                if (ModelState.IsValid)
                {
                    await _db.SaveChangesAsync();
                }
                else
                {

                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser (int id)
        {
            User u = _db.Users.FirstOrDefault(x => x.Id == id);

            if(u != null)
            {
                _db.Users.Remove(u);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}
