using Proiect_.net.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proiect_.net.Models
{
    public class Writes : BaseEntity
    {
        public Guid BookId { get; set; }        
        public Book Book { get; set; } = null!;       
        public Guid AuthorId { get; set; }     
        public Author Author { get; set; } = null!;
    }
}
