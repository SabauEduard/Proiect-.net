using Proiect_.net.Models.Base;
using Proiect_.net.Models.Enums;
using System.Text.Json.Serialization;

namespace Proiect_.net.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;

        [JsonIgnore]
        public string PasswordHash { get; set; } = null!;

        public Role Role { get; set; }
        [JsonIgnore]
        public virtual ICollection<Borrows> Borrows { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Penalty> Penalties { get; set; } = null!;
    }
}
