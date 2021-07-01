using BootcampFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Controllers
{
    public class MyFlatController : Controller
    {
        private readonly ModelContext _db;
        public MyFlatController(ModelContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.Name).Value;
            //int userId = int.Parse(id);

            //var myflats = _db.UserFlats.AsQueryable();

            //myflats = myflats.OrderByDescending(n => n.Id).Where(x => x.UserId == userId);

            //var a = myflats.ToList();
            ViewBag.a = id;

            return View(id);
        }
    }
}
