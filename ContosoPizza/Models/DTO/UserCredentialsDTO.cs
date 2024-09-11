namespace ContosoPizza.Models.DTO
{
    public record UserCredentialsDTO
    {
        public required string Id { get; set; }
        public int RoleId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
