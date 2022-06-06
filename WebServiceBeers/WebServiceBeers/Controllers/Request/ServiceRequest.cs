using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceBeers.Controllers.Request
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Brand { get; set; }
    }
}
