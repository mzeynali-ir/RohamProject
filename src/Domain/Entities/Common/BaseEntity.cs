namespace Domain.Entities.Common
{
    public abstract class BaseEntity<TKey> : ISoftDelete
        where TKey : struct
    {
        public TKey Id { get; init; }
        public DateTime CreatedOn { get; init; } = DateTime.Now;
        public DateTime? LastModifiedOn { get; set; }

        public bool IsDeleted { get; private set; }
        public void Delete()
        {
            this.IsDeleted = true;
        }
    }
}
