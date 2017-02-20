using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingNetCore.Api.Entities
{
    public class Company : EntityBase
    {
        public string Name { get; set; }
        public Address CompanyAddress { get; set; }
        public string CompanyBtwNumber { get; set; }
    }
}
