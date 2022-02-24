using Joyle.Accounts.Domain;
using Joyle.Accounts.Domain.UserRegistrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joyle.Accounts.Infra.Data.UserRegistrations
{
    internal class UserRegistrationMapping : IEntityTypeConfiguration<UserRegistration>
    {
        public void Configure(EntityTypeBuilder<UserRegistration> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
                .ValueGeneratedNever();

            builder.ToTable("UserRegistration");

            builder.OwnsOne(user => user.Username, username =>
            {
                username.Property(u => u.Value)
                    .IsRequired()
                    .HasColumnName("Username")
                    .HasColumnType($"VARCHAR({Username.MaxLength})");

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

            builder.Property(user => user.ConfirmationDate)
                .IsRequired(false);

            builder.Property(user => user.RegistrationDate)
                .IsRequired();

            builder.OwnsOne(user => user.Status, status =>
            {
                status.Property(s => s.Value)
                    .IsRequired()
                    .HasColumnName("Status")
                    .HasColumnType($"varchar(30)");

            }).Navigation(user => user.Status).IsRequired();
        }
    }
}
