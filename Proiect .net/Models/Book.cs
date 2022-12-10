using Proiect_.net.Models.Base;

namespace Proiect_.net.Models
{
    public class Book : BaseEntity
    {
        public string ISBN { get; set; } = "ISBN";
        public string Title { get; set; } = "Title";
        public string Description { get; set; } = "Description";
        int PageNumber { get; set; } = 0;
        public string Language { get; set; } = "Language";
        int ReleaseDate { get; set; } = 0;
        public virtual ICollection<Writes> Writes { get; set; } = default!;
        public virtual ICollection<Belongs> Belongs { get; set; } = default!;
        public virtual ICollection<Borrows> Borrows { get; set; } = default!;
    }
}
