using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Models
{
    public class UserFlat
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int? PaymentId { get; set; }
        [ForeignKey("PaymentId")]
        public virtual Payment Payment { get; set; }

        public int BuildingFlatId { get; set; }
        [ForeignKey("BuildingFlatId")]
        public virtual BuildingFlat BuildingFlat { get; set; }


    }
}
