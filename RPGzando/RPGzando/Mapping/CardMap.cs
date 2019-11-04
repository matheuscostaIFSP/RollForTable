using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using RPGzando.Models;

namespace RPGzando.Mapping
{
    public class CardMap : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.CardId);
            builder.Property(c => c.NameCharacter).IsRequired().HasMaxLength(50);
            builder.Property(c => c.PdfLink).IsRequired().HasMaxLength(250);

            builder.HasOne(c => c.User).WithMany(c => c.Cards).HasForeignKey(c => c.UserId);
            builder.HasMany(c => c.TableSystemCards).WithOne(c => c.Card).HasForeignKey(c => c.TableSystemCardId);

            builder.ToTable("Cards");
        }
    }
}
