using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace homework8
{
    public class OrderItem
    {      
        [Key]
        public string id { get; set; }
        
        public string productName { get; set; }
        public double productPrice { get; set; }
        public DateTime orderTime{ get; set; }
        public int buyNum { get; set; }
        [Required]
        public string orderID { get; set; }
        public  Order order { get; set; }
    }
}
