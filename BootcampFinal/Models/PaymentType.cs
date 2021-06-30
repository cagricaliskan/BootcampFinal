using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Payment> Payments{ get; set; }

    }
}
