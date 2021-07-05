using BootcampFinal.Models;
using CreditCardService.Model.Mongo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Controllers
{
    [Authorize]
    public class MakePaymentController : Controller
    {
        private readonly CreditCardService.Services.CreditCardService _creditCardService;
        private readonly ModelContext _db;

        public MakePaymentController(CreditCardService.Services.CreditCardService creditCardService, ModelContext db)
        {
            _db = db;
            _creditCardService = creditCardService;
        }

        public async Task<IActionResult> Payment(int? paymentId)
        {
            var payment = _db.AppointedPayments.FirstOrDefault(x => x.PaymentId == paymentId);
            return View(payment);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(CreditCard creditCard, int money, int paymentId)
        {
            bool result = await _creditCardService.WithdrawMoney(creditCard, money);


            var update = _db.AppointedPayments.FirstOrDefault(x => x.PaymentId == paymentId);

            if (update != null)
            {
                update.isPaid = true;

                if (ModelState.IsValid)
                {
                    await _db.SaveChangesAsync();
                }
            }
                return RedirectToAction("Index","MyFlat");
        }
    }
}
