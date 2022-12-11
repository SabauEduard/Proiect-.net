using Proiect_.net.Models.Base;

namespace Proiect_.net.Models
{
    public class Author : BaseEntity
    {   
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Nationality { get; set; } 
        public virtual ICollection<Writes> Writes { get; set; } = default!;

    }
}
