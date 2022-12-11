using Proiect_.net.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_.net.Models
{
    public class Writes : BaseEntity
    {
        public Guid BookId { get; set; } 
        public virtual Book Book { get; set; } = default!;
        
        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; } = default!;
    }
}
