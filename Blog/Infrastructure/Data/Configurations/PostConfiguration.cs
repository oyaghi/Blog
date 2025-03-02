using Blog.Core.AggregatesModel.CommentAggregateModel;
using Blog.Core.AggregatesModel.PostAggregateModel;
using Blog.Core.AggregatesModel.UserAggregateModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Data.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Content)
            .IsRequired();

        builder.Property(p => p.Category)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasConversion<string>();

        builder.Property(p => p.Tag)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasConversion<string>();

        builder.HasMany<Comment>(p => p.Comments)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey(v => v.PostId);

        builder.HasOne<User>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(v => v.UserId);
    }
}