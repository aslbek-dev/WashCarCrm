using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashCarCrm.Domain
{
    public class Washer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        public int Stake { get; set; }
        public byte[] Image { get; set; }
        public bool isActive { get; set; }

        //ef relations
        public IQueryable<Order> Orders { get; set; }
    }
}