using OlderTask.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlderTask.Domain.Entities
{
    [Table("Orders", Schema = "OrderTask")]
    public class Order :Auditing
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
