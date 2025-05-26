using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ItSystem> ItSystems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed some sample data
        modelBuilder.Entity<ItSystem>().HasData(
            new ItSystem
            {
                Id = 1,
                Name = "HR System",
                Description = "Human Resources Management System",
                Owner = "HR Department",
                TechnicalOwner = "IT Support Team",
                Version = "2.1.3",
                InstallationDate = new DateTime(2023, 5, 15),
                LastUpdateDate = new DateTime(2025, 2, 10),
                Status = SystemStatus.Active
            },
            new ItSystem
            {
                Id = 2,
                Name = "CRM Solution",
                Description = "Customer Relationship Management System",
                Owner = "Sales Department",
                TechnicalOwner = "IT Development Team",
                Version = "3.5.0",
                InstallationDate = new DateTime(2022, 8, 20),
                LastUpdateDate = new DateTime(2025, 4, 5),
                Status = SystemStatus.Active
            },
            new ItSystem
            {
                Id = 3,
                Name = "Legacy Inventory System",
                Description = "Old inventory tracking system",
                Owner = "Warehouse Department",
                TechnicalOwner = "External Vendor",
                Version = "1.8.7",
                InstallationDate = new DateTime(2018, 3, 10),
                LastUpdateDate = new DateTime(2022, 11, 15),
                Status = SystemStatus.Deprecated
            }
        );
    }
}
