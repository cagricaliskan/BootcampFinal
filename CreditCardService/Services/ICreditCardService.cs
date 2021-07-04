using CreditCardService.Model.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardService.Services
{
    interface ICreditCardService
    {
        Task<bool> WithdrawMoney(CreditCard creditCard, int money);
    }
}
