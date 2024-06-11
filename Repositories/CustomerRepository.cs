using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace Repositories
{
     public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomerById(int id)
            => Customer.GetCustomerById(id);
    }
    
}
