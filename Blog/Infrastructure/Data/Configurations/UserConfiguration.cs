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
        builder.HasMany<Post>()
            .WithOne()
            .IsRequired(false)
            .HasForeignKey(v => v.UserId);
    }
}