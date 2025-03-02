using Blog.Core.AggregatesModel.CommentAggregateModel;
using Blog.Core.AggregatesModel.InteractionAggregateModel;
using Blog.Core.AggregatesModel.PostAggregateModel;
using Blog.Core.AggregatesModel.UserAggregateModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Username)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(u => u.Password)
            .HasMaxLength(128)
            .IsRequired();
        
        builder.Property(c => c.Email)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.HasMany<Post>()
            .WithOne()
            .IsRequired(false)
            .HasForeignKey(v => v.UserId);
        
        builder.HasMany<Comment>()
            .WithOne()
            .IsRequired(false)
            .HasForeignKey(v => v.UserId);
        
        builder.HasMany<Interaction>( u => u.Interactions)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey(v => v.UserId);
    }
}