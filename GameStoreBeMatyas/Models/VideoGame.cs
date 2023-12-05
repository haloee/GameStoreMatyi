using Azure;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameStoreBeMatyas.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum type { Akció = 1, Kaland, Coop, Oktató, Túlélő }
    public class VideoGame
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        [EnumDataType(typeof(type))]
        public type Type { get; set; }
        public int Price { get; set; }
        [Required, Range(1, 5)]
        public int Rating { get; set; }
        [JsonIgnore]
        public List<User> Users { get; } = new();
    }
}
