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
    [Authorize("Administrator")]
    public class ResidentHouseController : Controller
    {
        private readonly ModelContext _db;

        public ResidentHouseController(ModelContext db)
        {
            _db = db;
        }

        public IActionResult Index(int page =1, string search = "")
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
            ViewBag.user = _db.Users.Where(x => x.UserRole == UserRole.Resident).ToList();
            ViewBag.bf = _db.BuildingFlats.ToList();
            return View(rh.ToPagedList(page,10));
        }

        [HttpPost]
        public IActionResult AddRH(UserFlat userFlat)
        {
            if(userFlat != null)
            {
                _db.UserFlats.Add(userFlat);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetRH(int id)
        {
            var rh = _db.UserFlats.Select(x => new UserFlat { Id = x.Id, BuildingFlatId = x.BuildingFlatId, PaymentId = x.PaymentId, UserId = x.UserId }).FirstOrDefault(n => n.Id == id);
            return Json(rh);
        }

        [HttpPost]
        public async Task<IActionResult> EditRH(UserFlat userFlat)
        {
            var rh = _db.UserFlats.FirstOrDefault(x => x.Id == userFlat.Id);

            if(rh != null)
            {
                rh.BuildingFlatId = userFlat.BuildingFlatId;
                rh.PaymentId = userFlat.PaymentId;
                rh.UserId = userFlat.UserId;

                if (ModelState.IsValid)
                {
                    await _db.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRH(int id)
        {
            var rh = _db.UserFlats.FirstOrDefault(x => x.Id == id);

            if(rh != null)
            {
                _db.Remove(rh);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
