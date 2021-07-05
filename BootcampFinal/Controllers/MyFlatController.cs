using BootcampFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BootcampFinal.Controllers
{
    public class MyFlatController : Controller
    {
        private readonly ModelContext _db;
        public MyFlatController(ModelContext db)
        {
            _db = db;
        }
        [Authorize("Resident")]
        public IActionResult Index(int page = 1, string search = "")
        {
            var id = User.Claims.Where(p => p.Type == System.Security.Claims.ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            int userId = int.Parse(id);

            var myflats = _db.AppointedPayments.AsQueryable();
            ViewBag.page = page;

            myflats = myflats.Where(x => x.UserFlat.User.Id == userId).OrderByDescending(n => n.Id);

            var a = myflats.ToList();

            return View(myflats.ToPagedList(page,10));
        }
    }
}
