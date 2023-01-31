namespace Proiect_.net.Models.DTOs.Authors
{
    public class AuthorResponseDTO
    {
        public Guid Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Nationality { get; set; } = null!;        
        public AuthorResponseDTO(Author author)
        {
            Id = author.Id;
            LastName = author.LastName;
            FirstName = author.FirstName;
            Nationality = author.Nationality;          
        }
    }
}
