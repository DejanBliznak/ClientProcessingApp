using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AddressModel
    {
        public int Id { get; set; } 
        public string AddressLine { get; set; }
        public int Type { get; set; }
    }
}
