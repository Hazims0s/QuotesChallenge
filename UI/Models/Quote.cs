namespace UI.Models
{
    public class Quote : BaseEntity
    {
        public string Text { get; set; }
        public virtual Auther Auther { get; set; }
    }
}
