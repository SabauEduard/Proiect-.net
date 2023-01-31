using Proiect_.net.Models.Base;
using System.Text.Json.Serialization;

namespace Proiect_.net.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;       
        public ICollection<Belongs> Belongs { get; set; } = null!;
    }
}
