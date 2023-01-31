using Proiect_.net.Models.Base;
using System.Text.Json.Serialization;

namespace Proiect_.net.Models
{
    public class Penalty : BaseEntity
    {
        public int Amount { get; set; } = 0;
        public string Reason { get; set; } = null!;
        public User User { get; set; }
        public Guid UserId { get; set; }
        public PenaltyReceipt PenaltyReceipt { get; set; } = null!;
    }
}
