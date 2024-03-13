using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Product
{
    public sealed class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(int id) : base($"Product has the id {id} not found")
        { 
        }   
    }
}
