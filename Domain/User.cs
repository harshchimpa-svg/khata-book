using Domain.Enums;

namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public int CountryCode { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public RoleType RoleType { get; set; }
        public bool IsEmailVerified { get; set; }
    }

}
