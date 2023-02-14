using Client.DTOs.AutherDTOs;

namespace Client.Models
{
    public class AuthersVM
    {
        public string Text { get; set; }
        public Guid AutherId { get; set; }
        public List<AutherDTO>  Authers { get; set; } 
    }
}
