using BootcampFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BootcampFinal.Controllers
{
    public class ResidentHouseController : Controller
    {
        private readonly ModelContext _db;

        public ResidentHouseController(ModelContext db)
        {
            _db = db;
        }

        public IActionResult Index(int page =1, string search = " ")
        {
            
            var rh = _db.UserFlats.AsQueryable();

            if (search != null)
            {
                rh = _db.UserFlats.Where(x => x.BuildingFlat.Building.Name.Contains(search) || x.BuildingFlat.FlatType.Name.Contains(search) || x.BuildingFlat.Flat.Name.Contains(search));

                ViewBag.search = search;
                ViewBag.count = rh.Count();
            }

            rh = rh.OrderBy(x => x.Id);
            ViewBag.page = page;
            ViewBag.ft = _db.FlatTypes.ToList();
            ViewBag.building = _db.Buildings.ToList();
            ViewBag.user = _db.Users.Where(x => x.UserRole == UserRole.Resident).ToList();
            ViewBag.flat = _db.Flats.ToList();
            return View(rh.ToPagedList(page,10));
        }
    }
}
