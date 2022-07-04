using Joyle.Accounts.Domain;
using Joyle.Accounts.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joyle.Accounts.Infra.Data.Users
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
                .ValueGeneratedNever();

            builder.ToTable("JoyleUser");

            builder.OwnsOne(user => user.Username, username =>
            {
                username.Property(u => u.Value)
                    .IsRequired()
                    .HasColumnName("Username")
                    .HasColumnType($"VARCHAR({Username.MaxLength})");

                username.HasIndex(u => u.Value)
                    .IsUnique();

            }).Navigation(user => user.Username).IsRequired();

            builder.OwnsOne(user => user.Email, email =>
            {
                email.Property(em => em.Address)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"VARCHAR({Email.MaxLength})");

            }).Navigation(user => user.Email).IsRequired();

            builder.Property(user => user.FullName)
                .IsRequired()
                .HasColumnType("VARCHAR(150)");

            builder.Property(user => user.Password)
                .IsRequired()
                .HasColumnType("VARCHAR(250)");

            builder.Property(user => user.IsActive)
                .IsRequired();

            builder.Property(user => user.InactivationDate)
                .IsRequired(false);
        }
    }
}
