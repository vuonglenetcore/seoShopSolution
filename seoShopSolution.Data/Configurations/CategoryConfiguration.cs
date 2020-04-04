using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using seoShopSolution.Data.Entities;
using seoShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace seoShopSolution.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();


            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
        }
    }
}
