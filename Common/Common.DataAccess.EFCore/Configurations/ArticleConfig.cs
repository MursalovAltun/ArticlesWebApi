using Common.DataAccess.EFCore.Configurations.System;
using Common.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configurations
{
    public class ArticleConfig : BaseEntityConfig<Article>
    {
        public ArticleConfig() : base("Articles") { }

        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Title)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(obj => obj.Description)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(obj => obj.Link)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();
        }
    }
}