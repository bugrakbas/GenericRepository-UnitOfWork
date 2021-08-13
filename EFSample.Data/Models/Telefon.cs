using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFSample.Data.Models
{
   public class Telefon
    {
       [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

    
    }
}
