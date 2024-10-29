using Microsoft.EntityFrameworkCore;

namespace FeedbackScan.Data
{
    public class FeedbackScanContext : DbContext
    {
        public FeedbackScanContext (DbContextOptions<FeedbackScanContext> options)
            : base(options)
        {
        }

        public DbSet<FeedbackScan.Models.CustomerFeedback> CustomerFeedback { get; set; } = default!;
    }
}