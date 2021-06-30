using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public virtual ICollection<UserFlat> UserFlats { get; set; }

        public int PaymentTypeId { get; set; }

        [ForeignKey("PaymentTypeId")]
        public virtual PaymentType PaymentType{ get; set; }


        public float Price { get; set; }
        public string Description{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
