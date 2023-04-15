using System.Text.Json.Serialization;

namespace WashCarCrm.Domain
{
    public class WashCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        // ef relations
        public Image Image { get; set; }
        [JsonIgnore]
        public IQueryable<Washer> Washers { get; set; } 
        [JsonIgnore]
        public IQueryable<Order> Orders { get; set; }
    }
}