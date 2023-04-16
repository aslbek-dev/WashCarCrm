using System.Text.Json.Serialization;
namespace WashCarCrm.Domain
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserRole
    {
        Admin,
        Owner
    }
}