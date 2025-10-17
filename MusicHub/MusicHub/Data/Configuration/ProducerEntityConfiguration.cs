using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicHub.Data.EntityValidationConstants.Producer;

namespace MusicHub.Data.Configuration
{
    public class ProducerEntityConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> entity)
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(ProducerNameMaxLength);
            entity.Property(p => p.Pseudonym)
                .IsUnicode()
                .IsRequired(false);
            entity.Property(p => p.PhoneNumber)
               .IsRequired(false);

        }
    }
}
