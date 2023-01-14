﻿namespace Proiect_.net.Models.DTOs.Categories
{
    public class CategoryResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CategoryResponseDTO(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }
    }
}