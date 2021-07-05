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
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly ModelContext _db;

        public VehicleController(ModelContext db)
        {
            _db = db;
        }
        public IActionResult Index(int page = 1, string search = "")
        {
            var v = _db.Vehicles.AsQueryable();

            if(search != "")
            {
                v = _db.Vehicles.Where(x => x.Plate.Contains(search) || x.Type.Contains(search) || x.User.Name.Contains(search) || x.User.LastName.Contains(search));

                ViewBag.search = search;
                ViewBag.count = v.Count();
            }

            v = v.OrderByDescending(x => x.Id);
            ViewBag.page = page;

            ViewBag.user = _db.UserFlats.ToList();

            return View(v.ToPagedList(page,10));
        }

        [HttpPost]
        public IActionResult AddVehicle(Vehicle v)
        {
            if(v != null)
            {
                _db.Vehicles.Add(v);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetVehicle(int id)
        {
            Vehicle v = _db.Vehicles.Select(x => new Vehicle { Id = x.Id, Plate = x.Plate, Type = x.Type, UserId = x.UserId }).FirstOrDefault(n => n.Id == id);

            return Json(v);
        }

        [HttpPost]
        public async Task<IActionResult> EditVehicle(Vehicle vehicle)
        {
            Vehicle v = _db.Vehicles.FirstOrDefault(x => x.Id == vehicle.Id);

            if(v != null)
            {
                v.Plate = vehicle.Plate;
                v.Type = vehicle.Type;
                v.UserId = vehicle.UserId;

                if (ModelState.IsValid)
                {
                    await _db.SaveChangesAsync();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            Vehicle v = _db.Vehicles.FirstOrDefault(x => x.Id == id);

            if(v != null)
            {
                _db.Vehicles.Remove(v);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
