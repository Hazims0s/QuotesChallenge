

namespace Domain
{
    public class Quote : BaseEntity
    {
        public string Text { get; set; }
        public Guid AutherId { get; set; }
        public virtual Auther Auther { get; set; }
    }
}