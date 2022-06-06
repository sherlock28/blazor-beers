using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppBeers.Data
{
    public class ServiceResponse<T>
    {
        public Boolean Success { get; set; }
        public String Message { get; set; }
        public T Data { get; set; }
    }
}
