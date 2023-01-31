namespace Proiect_.net.Models.DTOs.Authors
{
    public class AuthorWBookResponseDTO
    {
        public Guid Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public int NumberOfBooks { get; set; }

        public AuthorWBookResponseDTO(Author author, int noBooks)
        {
            Id = author.Id;
            LastName = author.LastName;
            FirstName = author.FirstName;
            Nationality = author.Nationality;
            NumberOfBooks = noBooks;
        }
    }
}
