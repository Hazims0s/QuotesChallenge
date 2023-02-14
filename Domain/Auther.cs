using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Auther : BaseEntity
    { 
        [Required]
        public string Name { get; set; } 
        public virtual ICollection<Quote> Quotes { get; set; }
    }
}