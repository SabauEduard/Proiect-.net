﻿using Proiect_.net.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proiect_.net.Models
{
    public class Belongs : BaseEntity
    {
        public Guid BookId { get; set; }
        
        public virtual Book Book { get; set; } = null!;
        
        public Guid CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; } = null!;
    }
}
