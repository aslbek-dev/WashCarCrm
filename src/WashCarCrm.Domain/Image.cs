using System.Text.Json.Serialization;
namespace WashCarCrm.Domain
{
    public class Image
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }

        [JsonIgnore]
        public WashCompany WashCompany { get; set; }
        [JsonIgnore]
        public Washer Washer {get; set;}
    }
}