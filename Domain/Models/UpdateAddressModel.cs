using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UpdateAddressModel
    {
        public int Id { get; set; }
        [Required]
        public string AddressLine { get; set; }
        [Required]
        public int Type { get; set; }
    }
}
