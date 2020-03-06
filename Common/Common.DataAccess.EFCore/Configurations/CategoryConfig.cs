using Common.DataAccess.EFCore.Configurations.System;
using Common.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess.EFCore.Configurations
{
    public class CategoryConfig : BaseEntityConfig<Category>
    {
        public CategoryConfig() : base("Categories") { }

        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(obj => obj.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(obj => obj.Articles)
                .WithOne(a => a.Category)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();
        }
    }
}