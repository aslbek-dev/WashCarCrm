using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.EntityTypeConfigurations
{
    public class ServiceTypeConfigurations : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(s => s.Name)
                .HasMaxLength(200);
        }
    }
}