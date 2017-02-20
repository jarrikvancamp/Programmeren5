using HerhalingNetCore.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingNetCore.Api.Api.Models.Customer
{
    public class CustomerEdit
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int BillingAddress { get; set; }
        public int DeliveryAddres { get; set; }
    }
}
