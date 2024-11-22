namespace EventManagementSystemADV.Models
{
    public class Volunteer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; 
        public string FullName => $"{FirstName} {LastName}";
    }
}
