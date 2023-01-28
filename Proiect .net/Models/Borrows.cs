using Proiect_.net.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proiect_.net.Models
{
    public class Borrows : BaseEntity
    {  
        public Guid UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; } = null!;

        public Guid BookId { get; set; }
        [JsonIgnore]
        public virtual Book Book { get; set; } = null!;
    }
}
