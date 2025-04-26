using LeadsFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeadsFlow.Infrastructure.DataAccess;

public class LeadsFlowDbContext : DbContext
{
    public LeadsFlowDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Lead> Leads { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeadsFlowDbContext).Assembly);
    }
}