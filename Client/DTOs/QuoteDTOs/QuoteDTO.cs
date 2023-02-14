
using Client.DTOs.AutherDTOs;

namespace Client.DTOs.QuotesDTOs
{
    public class QuoteDTO
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public AutherDTO Auther { get; set; }

    }
}