using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingNetCore.Api.Entities
{
    public class Person : EntityBase
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }        
    }
}
