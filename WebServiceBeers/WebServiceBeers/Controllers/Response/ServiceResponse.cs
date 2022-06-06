using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBeers.Models;

namespace WebServiceBeers.Controllers.Response
{
    public class ServiceResponse<T>
    {
        public Boolean Success { get; set; }
        public String Message { get; set; }
        public T Data { get; set; }

        public ServiceResponse()
        {
            this.Success = false;
        }
    }
}
