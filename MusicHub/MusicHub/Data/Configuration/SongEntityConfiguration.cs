using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicHub.Data.EntityValidationConstants.Song;

namespace MusicHub.Data.Configuration
{
    public class SongEntityConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Song> entity)
        {
            //Defines PK
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Name)
                    .IsRequired(true)
                    .IsUnicode(true)
                    .HasMaxLength(SongNameMaxLength);
            //Optional
            entity.Property(s => s.Duration)
                     .IsRequired();
            entity.Property(s => s.CreatedOn)
                     .IsRequired();
            entity.Property(s => s.Genre)
                    .IsRequired();
            entity.Property(s => s.Price)
                    .IsRequired();
            entity.Property(s => s.AlbumId)
                    .IsRequired(false);
            entity.Property(s => s.WriterId)
                    .IsRequired();

            //Relations
            entity.
                HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId);
            entity
                .HasOne(s => s.Writer)
                .WithMany(w => w.Songs)
                .HasForeignKey(s => s.WriterId);


        }
    }
}
