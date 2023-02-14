
using Application.DTOs.AutherDTOs;

namespace Application.DTOs.QuotesDTOs
{
    public class QuoteDTO
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public AutherDTO Auther { get; set; }

    }
}