using Proiect_.net.Models.Base;

namespace Proiect_.net.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = "Category Name";
        public virtual ICollection<Belongs> Belongs { get; set; } = default!;
    }
}
