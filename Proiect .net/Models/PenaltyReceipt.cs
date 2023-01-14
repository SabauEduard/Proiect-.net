using Proiect_.net.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_.net.Models
{
    public class PenaltyReceipt : BaseEntity
    {
        [ForeignKey("PenaltyId")]
        public int PaidAmount { get; set; } = 0;
        public Guid PenaltyId { get; set; }
        public virtual Penalty Penalty { get; set; }
    }
}
