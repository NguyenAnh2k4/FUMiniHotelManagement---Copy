using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public partial class Customer
    {
        public Customer() { }
        public int CustomerID {  get; set; }
        public string CustomerFullName { get; set; }
        public string? Telephone {  get; set; }
        public string EmailAddress {  get; set; }
        public DateTime CustomerBirthday { get; set; }
        public short CustomerStatus {  get; set; }
        public string Password {  get; set; }
    }
}
