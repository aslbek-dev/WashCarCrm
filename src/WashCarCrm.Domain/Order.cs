using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashCarCrm.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public string ClientName { get; set; }
        public string ClientNumber { get; set; }
        
        public bool IsActive { get; set; }
        public bool IsCancelled { get; set; }
        public DateTimeOffset DateTime { get; set; }

        //foreign keys
        public int WashCompanyId { get; set; }

        // ef relations
        public WashCompany WashCompany { get; set; }
        public IQueryable<Washer> Washers { get; set; }
        public IQueryable<Service> Services { get; set; }
    }
}