using Data.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Address : BaseEntity
    {       
        public string AddressLine { get; set; }
        public int Type { get; set; } 
        public int ClientID { get; set; }
        
    }
}
