﻿using System.ComponentModel.DataAnnotations;

namespace Proiect_.net.Models.DTOs.Write
{
    public class WritesRequestDTO
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
    }
}
