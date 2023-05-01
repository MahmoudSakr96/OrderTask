using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlderTask.Domain.Common;

namespace OlderTask.Domain.Entities
{

    [Table("OrderDetails", Schema = "OrderTask")]
    public class OrderDetail : Auditing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ItemNo { get; set; }

        [MaxLength(1000)]
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }

        [Required, ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

    }
}
