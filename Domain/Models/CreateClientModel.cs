using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CreateClientModel
    {
      
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime? BirthDate { get; set; }

        public List<CreateAddressModel> Addresses { get; set; }
    }
}
