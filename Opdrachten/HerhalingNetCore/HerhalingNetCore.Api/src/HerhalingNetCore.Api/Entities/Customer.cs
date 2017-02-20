using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingNetCore.Api.Entities
{
    public class Customer : Person
    {
        public Address BillingAddress { get; set; }
        public Address DeliveryAddres { get; set; }
    }
}
