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
    public class FlatTypesController : Controller
    {

        private readonly ModelContext _db;

        public FlatTypesController(ModelContext db)
        {
            _db = db;
        }
        public IActionResult Index(int page = 1)
        {
            var ft = _db.FlatTypes.AsQueryable();
            ft = ft.OrderByDescending(x => x.Id);
            ViewBag.page = page;


            return View(ft.ToPagedList(page, 10));
        }

        [HttpPost]
        public IActionResult AddFlatType(FlatType flatType)
        {
            if(flatType != null)
            {
                _db.Add(flatType);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        public JsonResult GetFlatType(int id)
        {
            FlatType ft = _db.FlatTypes.Select(x => new FlatType { Id = x.Id, Name = x.Name }).FirstOrDefault(n => n.Id == id);
            return Json(ft);
        }

        [HttpPost]
        public async Task<IActionResult> EditFlatType(FlatType flatType) 
        {
            var ft = _db.FlatTypes.FirstOrDefault(x => x.Id == flatType.Id);

            if(ft != null)
            {
                ft.Name = flatType.Name;

                if (ModelState.IsValid)
                {
                    await _db.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
