using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicHub.Data.EntityValidationConstants.Album;

namespace MusicHub.Data.Configuration
{
    public class AlbumEntityConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Album> entity)
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(AlbumNameMaxLength);

            entity.Property(a => a.ReleaseDate)
                .IsRequired();
            entity.Property(a => a.ProducerId)
                .IsRequired(false);

            //Relations
            entity
                .HasOne(a => a.Producer)
                .WithMany(p => p.Albums)
                .HasForeignKey(a => a.ProducerId);


        }
    }
}
