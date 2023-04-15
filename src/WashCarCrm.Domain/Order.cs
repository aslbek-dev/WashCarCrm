using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
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
        public int WashCompanyId { get; set; }
        public int ServiceId { get; set; }
        public int WasherId { get; set; }

        public DateTimeOffset DateTime { get; set; }

        // ef relations
        [JsonIgnore]
        public WashCompany WashCompany { get; set; }
        [JsonIgnore]
        public Washer Washer { get; set; }
        [JsonIgnore]
        public Service Service { get; set; }
    }
}