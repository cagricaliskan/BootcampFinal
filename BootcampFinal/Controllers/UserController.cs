using BootcampFinal.Models;
using BootcampFinal.Services;
using BootcampFinal.ViewString;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BootcampFinal.Controllers
{
    [Authorize("Administrator")]
    public class UserController : Controller
    {
        private readonly ModelContext _db;
        private readonly IEmailService _emailSender;

        public UserController(ModelContext db, IEmailService emailSender)
        {
            _db = db;
            _emailSender = emailSender;
        }

        public IActionResult Index(int page = 1, string search = "")
        {
            var users = _db.Users.Where(x => x.UserRole == UserRole.Resident);

            if (search != "")
            {
                users = users.Where(x => x.Name.Contains(search) || x.LastName.Contains(search));

                ViewBag.search = search;
                ViewBag.searhCount = users.Count();
            }

            users = users.OrderByDescending(n => n.Id);
            ViewBag.page = page;

            return View(users.ToPagedList(page, 10));
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {

            if (user != null)
            {

                Random r = new Random();
                var x = r.Next(0, 1000000);
                string s = x.ToString("000000");

                user.Password = s;
                _db.Add(user);
                await _db.SaveChangesAsync();

                string str =  await ViewToStringRenderer.RenderViewToStringAsync(HttpContext.RequestServices, $"~/Views/EMail/NoLinkEMailTemplate.cshtml", $"Hi {user.Name}, your account is created, your password is {user.Password}");
                await _emailSender.Send(user.Email, "Apsis Account", str);
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
            if (u != null)
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
        public async Task<IActionResult> DeleteUser(int id)
        {
            User u = _db.Users.FirstOrDefault(x => x.Id == id);

            if (u != null)
            {
                _db.Users.Remove(u);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
