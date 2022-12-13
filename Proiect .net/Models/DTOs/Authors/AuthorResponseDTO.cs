namespace Proiect_.net.Models.DTOs.Authors
{
    public class AuthorResponseDTO
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Nationality { get; set; }

        public AuthorResponseDTO(Author author)
        {
            Id = author.Id;
            LastName = author.LastName;
            FirstName = author.FirstName;
            Nationality = author.Nationality;
        }
    }
}
