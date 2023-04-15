using System.Text.Json.Serialization;

namespace WashCarCrm.Domain
{
    public class Washer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        public int Stake { get; set; }
        public bool isActive { get; set; }

        //ef relations
        public Image Image { get; set; }
        public WashCompany washCompany { get; set; }
        [JsonIgnore]
        public IQueryable<Order> Orders { get; set; }
    }
}