using Proiect_.net.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proiect_.net.Models
{
    public class PenaltyReceipt : BaseEntity
    {
        [ForeignKey("PenaltyId")]
        public int PaidAmount { get; set; } = 0;
        public Guid PenaltyId { get; set; }
        [JsonIgnore]
        public virtual Penalty Penalty { get; set; } = null!;
    }
}
