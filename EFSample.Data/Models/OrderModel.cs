using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFSample.Data.Models
{
    public class OrderModel 
    {
        [Key]
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string CardNumber { get; set; }
        public int UserId { get; set; }

    }
}
