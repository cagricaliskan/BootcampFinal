using BootcampFinal.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize("Resident")]
        public IActionResult Index()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            int userId = int.Parse(id);

            var myflats = _db.UserFlats.AsQueryable();

            myflats = myflats.Where(x => x.UserId == userId).OrderByDescending(n => n.Id);

            var a = myflats.ToList();

            return View(a);
        }
    }
}
