using Microsoft.EntityFrameworkCore;

namespace Kolos_2_poprawa.Data;

public class KolosContext : DbContext
{
    public KolosContext(DbContextOptions<KolosContext> options) : base(options)
    {
    }
    
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var foreignKey in entityType.GetForeignKeys())
            {
                
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        
        
        
    }
}