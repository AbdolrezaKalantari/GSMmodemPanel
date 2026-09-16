namespace GsmPanel.models
{
    public class UserModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? BirthDay { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string GroupType { get; set; } = "Default";
        public string Description { get; set; } = "Default";
    }
}
