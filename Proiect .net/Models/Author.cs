using Proiect_.net.Models.Base;

namespace Proiect_.net.Models
{
    public class Author : BaseEntity
    {   
        public string LastName { get; set; } = "Last Name";
        public string FirstName { get; set; } = "First Name";
        public string Nationality { get; set; } = "Nationality";
        public virtual ICollection<Writes> Writes { get; set; } = default!;

    }
}
