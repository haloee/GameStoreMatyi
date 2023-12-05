using Azure;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameStoreBeMatyas.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; }
        [Required, MaxLength(255)]
        public string PasswordHash { get; set; }
        public List<VideoGame> VideoGames { get; } = new();
    }
}
