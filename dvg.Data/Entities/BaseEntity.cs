namespace dvg.Data.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; init; }
        public DateTime CreateDate { get; init; }
        public DateTime? UpdateDate { get; set; }

    }
}
