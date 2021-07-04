using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Services
{
    public interface IEmailService
    {
        Task Send(string to, string subject, string html);

    }
}
