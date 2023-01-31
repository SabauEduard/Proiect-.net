using Proiect_.net.Models.Base;
using System.Text.Json.Serialization;

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
        
        public ICollection<Writes> Writes { get; set; } = null!;
        
        public ICollection<Belongs> Belongs { get; set; } = null!;
        
        public ICollection<Borrows> Borrows { get; set; } = null!;
    }
}
