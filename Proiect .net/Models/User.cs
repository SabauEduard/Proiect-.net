using Proiect_.net.Models.Base;
using Proiect_.net.Models.Enums;
using System.Text.Json.Serialization;

namespace Proiect_.net.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = "First Name";
        public string LastName { get; set; } = "Last Name";

        public string Email { get; set; } = "Email";
        public string Username { get; set; } = "Username";

        [JsonIgnore]
        public string PasswordHash { get; set; } = "Password Here";

        public Role Role { get; set; }
        public virtual ICollection<Borrows> Borrows { get; set; } = default!;
    }
}
