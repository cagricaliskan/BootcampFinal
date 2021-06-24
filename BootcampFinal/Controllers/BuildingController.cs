using BootcampFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BootcampFinal.Controllers
{
    public class BuildingController : Controller
    {
        private readonly ModelContext _db;
        public BuildingController(ModelContext db)
        {
            _db = db;
        }
        public IActionResult Index(int page = 1, string search = "")
        {
            var building = _db.Buildings.AsQueryable();

            if(search != "")
            {
                building = _db.Buildings.Where(x => x.Name.Contains(search));

                ViewBag.search = search;
                ViewBag.count = building.Count();
            }

            building = building.OrderByDescending(x => x.Id);
            ViewBag.page = page;


            return View(building.ToPagedList(page,10));
        }

        [HttpPost]
        public IActionResult AddBuilding(Building building)
        {
            if(building != null)
            {
                _db.Add(building);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public JsonResult GetBuilding(int id)
        {
            Building b = _db.Buildings.Select(x => new Building { Id = x.Id, Name = x.Name, Floor = x.Floor }).FirstOrDefault(n => n.Id == id);
            return Json(b);
        }

        [HttpPost]
        public async Task<IActionResult> EditBuilding(Building building)
        {
            Building b = _db.Buildings.FirstOrDefault(x => x.Id == building.Id);
            if(b != null)
            {
                b.Name = building.Name;
                b.Floor = building.Floor;

                if (ModelState.IsValid)
                {
                    await _db.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            Building b = _db.Buildings.FirstOrDefault(x => x.Id == id);
            
            if( b != null)
            {
                _db.Buildings.Remove(b);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
