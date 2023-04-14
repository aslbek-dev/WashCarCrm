using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashCarCrm.Domain
{
    public class WashCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        // ef relations
        public Image Image { get; set; }
        public IQueryable<Washer> Washers { get; set; } 
        public IQueryable<Order> Orders { get; set; }
    }
}