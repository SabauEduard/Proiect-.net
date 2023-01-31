﻿using System.ComponentModel.DataAnnotations;

namespace Proiect_.net.Models.DTOs.Belong
{
    public class BelongsRequestDTO
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
    }
}