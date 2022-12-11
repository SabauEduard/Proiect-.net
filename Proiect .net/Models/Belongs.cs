using Proiect_.net.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_.net.Models
{
    public class Belongs : BaseEntity
    {
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; } = default!;
        
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; } = default!;
    }
}
