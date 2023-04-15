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
        public int WashCompanyId { get; set; }
        [JsonIgnore]
        public int ImageId { get; set; }

        //ef relations
        public Image Image { get; set; }
        [JsonIgnore]
        public WashCompany WashCompany { get; set; }
        [JsonIgnore]
        public List<Order> Orders { get; set; }
    }
}