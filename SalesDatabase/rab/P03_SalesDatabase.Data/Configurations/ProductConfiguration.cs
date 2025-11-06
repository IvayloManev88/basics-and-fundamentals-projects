using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_SalesDatabase.Data.Configurations
{
    public class Productfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(c => c.ProductId);

            entity.Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

        }
    }
}
