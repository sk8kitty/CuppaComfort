using CuppaComfort.Models;
using Microsoft.EntityFrameworkCore;

namespace CuppaComfort.Data
{
    public class CuppaDbContext : DbContext
    {
        public CuppaDbContext(DbContextOptions<CuppaDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ConsumableProduct> ConsumableProducts { get; set; }
        public DbSet<MerchandiseProduct> MerchandiseProducts { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
