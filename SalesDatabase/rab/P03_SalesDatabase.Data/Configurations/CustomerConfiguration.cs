using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace P03_SalesDatabase.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> entity)
        {
            entity.HasKey(c => c.CustomerId);

            entity.Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

            entity.Property(c => c.Email)
               .IsRequired(false)
               .IsUnicode(false)
               .HasMaxLength(80);

            entity.Property(c => c.CreditCardNumber)
               .IsRequired(false);

        }
    }
}
