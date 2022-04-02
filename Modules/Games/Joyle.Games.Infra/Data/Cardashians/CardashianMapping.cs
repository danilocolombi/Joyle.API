using Joyle.Games.Domain.Cardashians;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joyle.Games.Infra.Data.Cardashians
{
    public class CardashianMapping : IEntityTypeConfiguration<Cardashian>
    {
        public void Configure(EntityTypeBuilder<Cardashian> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("Cardashian");

            builder.Property(c => c.AuthorId)
                .IsRequired();

            builder.Property(c => c.Title)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.Property(c => c.IsPublic)
                .IsRequired();

            builder.Property(c => c.CreationDate)
                .IsRequired();

            builder.OwnsMany<CardashianCard>("Cards", cardBuilder =>
            {
                cardBuilder.WithOwner().HasForeignKey(c => c.CardashianId);

                cardBuilder.ToTable("CardashianCard");

                cardBuilder.HasKey(c => c.Id);

                cardBuilder.Property(c => c.Id)
                    .ValueGeneratedNever();

                cardBuilder.Property(c => c.Description)
                    .HasColumnType("VARCHAR(255)")
                    .IsRequired(true);

                cardBuilder.Property(c => c.Position)
                    .HasColumnType("TINYINT")
                    .IsRequired(true);
            });
        }
    }
}
