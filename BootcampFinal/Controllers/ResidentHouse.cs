using BootcampFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BootcampFinal.Controllers
{
    public class ResidentHouse : Controller
    {
        private readonly ModelContext _db;

        public ResidentHouse(ModelContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            int page = 1;
            var rh = _db.UserFlats.AsQueryable();

            ViewBag.ft = _db.FlatTypes.ToList();
            ViewBag.building = _db.Buildings.ToList();
            ViewBag.user = _db.Users.Where(x => x.UserRole == UserRole.Resident).ToList();
            ViewBag.flat = _db.Flats.ToList();
            return View(rh.ToPagedList(page,10));
        }
    }
}
