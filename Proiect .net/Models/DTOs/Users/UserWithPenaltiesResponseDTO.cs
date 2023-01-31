namespace Proiect_.net.Models.DTOs.Users
{
    public class UserWithPenaltiesResponseDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Penalty> Penalties { get; set; }
        
        public UserWithPenaltiesResponseDTO(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;           
            Email = user.Email;
            Username = user.Username;
            Penalties = user.Penalties;
        }
    }
}

