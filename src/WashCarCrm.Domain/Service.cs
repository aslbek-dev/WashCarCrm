using System.Text.Json.Serialization;

namespace WashCarCrm.Domain
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }

        //ef relation
        [JsonIgnore]
        public List<Order> Orders { get; set; }
    }
}