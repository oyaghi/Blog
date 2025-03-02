using Blog.Core.AggregatesModel.CommentAggregateModel;
using Blog.Core.AggregatesModel.PostAggregateModel;
using Blog.Core.AggregatesModel.UserAggregateModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(c => c.Content)
            .HasMaxLength(500)
            .IsRequired();
        
        builder.HasOne<Post>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(v => v.PostId);
        
        builder.HasOne<User>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(v => v.UserId);
    }
}