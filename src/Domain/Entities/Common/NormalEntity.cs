using Domain.Entities.Users;

namespace Domain.Entities.Common
{
    public abstract class NormalEntity<TKey> : BaseEntity<TKey>, ISoftDelete
        where TKey : struct
    {
        public DateTime CreatedOn { get; init; } = DateTime.Now;
        public DateTime? LastModifiedOn { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; init; } = null!;

        public int? LastModifierId { get; set; }
        public User? LastModifier { get; init; }

        public bool IsDeleted { get; private set; }
        public void Delete()
        {
            this.IsDeleted = true;
        }
    }
}
