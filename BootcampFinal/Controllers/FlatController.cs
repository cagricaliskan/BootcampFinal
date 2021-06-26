using BootcampFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Controllers
{
    [Authorize("Administrator")]
    public class FlatController : Controller
    {
        private readonly ModelContext _db;

        public FlatController(ModelContext db)
        {

        }
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
