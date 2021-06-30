using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Models
{
    public class AppointedPayment
    {
        public int Id { get; set; }

        
        public int UserFlatId { get; set; }
        [ForeignKey("UserFlatId")]
        public virtual UserFlat UserFlat { get; set; }

        
        
        public int PaymentId { get; set; }
        
        [ForeignKey("PaymentId")]
        public virtual Payment Payment { get; set; }



        
    }
}
