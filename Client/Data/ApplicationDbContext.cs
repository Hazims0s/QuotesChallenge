using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Client.DTOs.QuotesDTOs;

namespace Client.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Client.DTOs.QuotesDTOs.QuoteDTO> QuoteDTO { get; set; } = default!;
        public DbSet<Client.DTOs.QuotesDTOs.UpdateQuoteDTO> UpdateQuoteDTO { get; set; } = default!;
    }
}