using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CreateAddressModel
    {
        [Required] 
        public string AddressLine { get; set; }
        [Required]
        public int Type { get; set; }
    }
}
