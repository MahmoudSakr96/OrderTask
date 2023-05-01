using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTask.Business.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Customer Name"), MaxLength(100)]
        public string CustomerName { get; set; }

        //[Required(ErrorMessage = "Please enter Order Date")]
        public DateTime Date { get; set; }
        public string HijriDate { get; set; }

        [Required(ErrorMessage = "Please enter your address"), MaxLength(500)]
        public string Address { get; set; }

        [Required]
        public int Phone { get; set; }
        public List <OrderDetailsDto>? OrderDetails { get; set; }
    }
}
