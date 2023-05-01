using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTask.Business.Dto
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string ItemNo { get; set; }
        [Required, MaxLength(200)]
        public string ItemDescription { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
        public int Total { get; set; }
        [Required]
        public int OrderId { get; set; }

    }
}
