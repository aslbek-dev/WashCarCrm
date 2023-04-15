using System.Text.Json.Serialization;

namespace WashCarCrm.Domain
{
    public class WashCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [JsonIgnore]
        public int ImageId { get; set;}

        // ef relations
        public Image Image { get; set; }
        [JsonIgnore]
        public List<Washer> Washers { get; set; } 
        [JsonIgnore]
        public List<Order> Orders { get; set; }
    }
}