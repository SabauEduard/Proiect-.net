using Proiect_.net.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_.net.Models
{
    public class Writes : BaseEntity
    {
        [Key, Column(Order = 1)]
        public Guid BookId { get; set; } 
        public Book Book { get; set; } = default!;
        
        [Key, Column(Order = 2)]
        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = default!;
    }
}
