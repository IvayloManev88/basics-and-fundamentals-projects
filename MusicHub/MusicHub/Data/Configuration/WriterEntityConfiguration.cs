using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicHub.Data.EntityValidationConstants.Writer;

namespace MusicHub.Data.Configuration
{
    public class WriterEntityConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> entity)
        {
            entity.HasKey(w => w.Id);
            entity.Property(w=>w.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(WriterNameMaxLength);
            entity.Property(w => w.Pseudonym)
                .IsRequired(false);
        }
    }
}
