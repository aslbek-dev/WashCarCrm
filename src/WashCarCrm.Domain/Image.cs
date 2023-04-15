using System.Text.Json.Serialization;
namespace WashCarCrm.Domain
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }

        // ef relations
        [JsonIgnore]
        public Washer Washer { get; set; }
        [JsonIgnore]
        public WashCompany WashCompany { get; set; }
    }
}