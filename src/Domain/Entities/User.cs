using Domain.Entities.Common;

namespace Domain.Entities
{
    public class User : NormalEntity<int>
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
    }

}
