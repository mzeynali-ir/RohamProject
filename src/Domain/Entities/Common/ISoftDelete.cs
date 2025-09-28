namespace Domain.Entities.Common
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; }
    }
}
