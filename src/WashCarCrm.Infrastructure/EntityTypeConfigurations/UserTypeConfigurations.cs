using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.EntityTypeConfigurations
{
    public class UserTypeConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder
                .Property(User => User.Id)
                .ValueGeneratedOnAdd();
            
            builder
                .HasIndex(u => u.Login)
                .IsUnique(true);
            builder
                .Property(u => u.Role)
                .HasConversion(new EnumToStringConverter<UserRole>());
        }
    }
}