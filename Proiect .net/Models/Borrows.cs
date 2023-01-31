using Proiect_.net.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proiect_.net.Models
{
    public class Borrows : BaseEntity
    {  
        public Guid UserId { get; set; }       
        public User User { get; set; } = null!;

        public Guid BookId { get; set; }      
        public Book Book { get; set; } = null!;
    }
}
