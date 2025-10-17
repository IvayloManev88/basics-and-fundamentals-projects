using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicHub.Data.EntityValidationConstants.Performer;

namespace MusicHub.Data.Configuration
{
    public class PerformerEntityConfiguration : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> entity)
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.FirstName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(FirstNameMaxLength);
            entity.Property(p => p.LastName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(LastNameMaxLength);
            entity.Property(p => p.Age)
                .IsRequired();
            entity.Property(p => p.NetWorth)
                .IsRequired();
        }
    }
}
