using Domain.Entities.Common;

namespace Domain.Entities.Users
{
    public class User : BaseEntity<int>
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
    }

}
