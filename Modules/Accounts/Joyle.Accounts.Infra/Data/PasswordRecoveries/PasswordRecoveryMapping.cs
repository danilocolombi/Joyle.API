using Joyle.Accounts.Domain;
using Joyle.Accounts.Domain.PasswordRecoveries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joyle.Accounts.Infra.Data.PasswordRecoveries
{
    public class PasswordRecoveryMapping : IEntityTypeConfiguration<PasswordRecovery>
    {
        public void Configure(EntityTypeBuilder<PasswordRecovery> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
                .ValueGeneratedNever();

            builder.ToTable("PasswordRecovery");

            builder.OwnsOne(passwordRecovery => passwordRecovery.Email, email =>
            {
                email.Property(em => em.Address)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"VARCHAR({Email.MaxLength})");

            }).Navigation(recovery => recovery.Email).IsRequired();


            builder.Property(recovery => recovery.CreationDate)
                .IsRequired();

            builder.Property(recovery => recovery.ExpirationDate)
                .IsRequired();

            builder.Property(recovery => recovery.RecoveryDate)
               .IsRequired(false);

            builder.OwnsOne(recovery => recovery.Status, status =>
            {
                status.Property(s => s.Value)
                    .IsRequired()
                    .HasColumnName("Status")
                    .HasColumnType($"VARCHAR(30)");

            }).Navigation(recovery => recovery.Status).IsRequired();
        }
    }
}
