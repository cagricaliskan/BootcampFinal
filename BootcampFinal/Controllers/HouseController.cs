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
    [AllowAnonymous]
    public class HouseController : Controller
    {

        private readonly ModelContext _db;

        public HouseController(ModelContext db)
        {
            _db = db;
        }


        public IActionResult Index(int page = 1, string search = "")
        {
            var house = _db.BuildingFlats.AsQueryable();
            if(search != null)
            {
                house = _db.BuildingFlats.Where(x => x.User.Name.Contains(search) || x.Building.Name.Contains(search) || x.FlatType.Name.Contains(search) || x.Flat.Name.Contains(search));

                ViewBag.search = search;
                ViewBag.count = house.Count();
            }

            house = house.OrderBy(x => x.BuildingId);
            ViewBag.page = page;

            ViewBag.ft = _db.FlatTypes.ToList();
            ViewBag.building = _db.Buildings.ToList();
            ViewBag.user = _db.Users.Where(x => x.UserRole == UserRole.Resident).ToList();
            ViewBag.flat = _db.Flats.ToList();
            

            return View(house.ToPagedList(page, 10));
        }

        [HttpPost]
        public IActionResult AddHouse(BuildingFlat buildingFlat)
        {
            if(buildingFlat != null)
            {
                _db.Add(buildingFlat);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetHouse(int id) 
        {
            var h = _db.BuildingFlats.Select(x => new BuildingFlat { Id = x.Id, BuildingId = x.BuildingId, FlatId = x.FlatId, FlatTypeId = x.FlatTypeId, UserId = x.UserId }).FirstOrDefault(n => n.Id == id);
            return Json(h);
        }

        [HttpPost]
        public async Task<IActionResult> EditHouse(BuildingFlat buildingFlat)
        {
            var h = _db.BuildingFlats.FirstOrDefault(x => x.Id == buildingFlat.Id);

            if(h != null)
            {
                h.BuildingId = buildingFlat.BuildingId;
                h.FlatId = buildingFlat.FlatId;
                h.FlatTypeId = buildingFlat.FlatTypeId;
                h.UserId = buildingFlat.UserId;

                if (ModelState.IsValid)
                {
                    await _db.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            var h = _db.BuildingFlats.FirstOrDefault(x => x.Id == id);

            if( h != null)
            {
                _db.Remove(h);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}
