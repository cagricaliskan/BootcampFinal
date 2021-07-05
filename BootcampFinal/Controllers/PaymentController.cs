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
    public class PaymentController : Controller
    {
        private readonly ModelContext _db;

        public PaymentController(ModelContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.user = _db.Users.Where(x => x.UserRole == UserRole.Resident).ToList();
            ViewBag.flat = _db.UserFlats.ToList();
            ViewBag.payment = _db.Payments.ToList();
            return View(Tuple.Create<IEnumerable<AppointedPayment>, IEnumerable<PaymentType>>(_db.AppointedPayments.ToList(), _db.PaymentTypes.ToList()));
        }

        [HttpPost]
        public IActionResult AddSinglePayment(AppointedPayment payment)
        {
            if(payment != null)
            {
                _db.AppointedPayments.Add(payment);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
