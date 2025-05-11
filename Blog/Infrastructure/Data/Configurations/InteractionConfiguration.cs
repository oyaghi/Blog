using Blog.Core.AggregatesModel.InteractionAggregateModel;
using Blog.Core.AggregatesModel.PostAggregateModel;
using Blog.Core.AggregatesModel.UserAggregateModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Data.Configurations;

public class InteractionConfiguration : IEntityTypeConfiguration<Interaction>
{
    public void Configure(EntityTypeBuilder<Interaction> builder)
    {
        builder.Property(i => i.Type)
            .HasMaxLength(25)
            .IsUnicode(false)
            .HasConversion<string>();
        
        builder.HasOne<Post>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(v => v.PostId);
    }
}