using Data.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Client : BaseEntity
    {       
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual List<Address> Addresses { get; set; }
    }
}
