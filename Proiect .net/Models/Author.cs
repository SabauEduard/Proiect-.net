using Proiect_.net.Models.Base;
using System.Text.Json.Serialization;

namespace Proiect_.net.Models
{
    public class Author : BaseEntity
    {   
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Nationality { get; set; }       
        public ICollection<Writes> Writes { get; set; } = null!;

    }
}
