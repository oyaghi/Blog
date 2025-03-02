using Blog.Core.AggregatesModel.CommentAggregateModel;
using Blog.Core.AggregatesModel.InteractionAggregateModel;
using Blog.Core.AggregatesModel.PostAggregateModel;
using Blog.Core.AggregatesModel.UserAggregateModel;

using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // apply all configuration specified in types implementing IEntityTypeConfiguration in a given assembly.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<User> Users { get; set; }
        
    public DbSet<Post> Posts { get; set; }
        
    public DbSet<Comment> Comments { get; set; }
        
    public DbSet<Interaction> Interactions { get; set; }
}