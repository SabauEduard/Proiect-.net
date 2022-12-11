using Proiect_.net.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_.net.Models
{
    public class Borrows : BaseEntity
    {  
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = default!;

        public Guid BookId { get; set; }
        public virtual Book Book { get; set; } = default!;
    }
}
