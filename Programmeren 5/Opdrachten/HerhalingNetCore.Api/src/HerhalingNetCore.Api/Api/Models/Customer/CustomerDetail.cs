using HerhalingNetCore.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingNetCore.Api.Api.Models.Customer
{
    public class CustomerDetail : BaseModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Address BillingAddress { get; set; }
        public Address DeliveryAddres { get; set; }
    }
}
