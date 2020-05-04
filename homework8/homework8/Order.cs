using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace homework8
{
   public class Order
    {
        [Key]
        public string orderID { get; set; }
        [Required]
        public string receiverName { get; set; }
        public string receiverAddress { get; set; }
        public string receiverPhone { get; set; }
        public List<OrderItem> orderItems  { get; set; }
   
    }
}
