﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingNetCore.Api.Entities
{
    public class Address : EntityBase
    {
        //TODO: refactor redundancy
        public string StreetName { get; set; }
        public string Number { get; set; }
        public string BusNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
