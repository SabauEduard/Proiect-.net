using Proiect_.net.Models.Base;

namespace Proiect_.net.Models
{
    public class Book : BaseEntity
    {
        public string ISBN { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; } 
        public int PageNumber { get; set; } 
        public string Language { get; set; } = null!;
        public int ReleaseDate { get; set; } 
        public virtual ICollection<Writes> Writes { get; set; } = default!;
        public virtual ICollection<Belongs> Belongs { get; set; } = default!;
        public virtual ICollection<Borrows> Borrows { get; set; } = default!;
    }
}
