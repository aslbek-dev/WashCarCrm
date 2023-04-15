using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.EntityTypeConfigurations
{
    public class WasherTypeConfigurations : IEntityTypeConfiguration<Washer>
    {
        public void Configure(EntityTypeBuilder<Washer> builder)
        {
            builder.ToTable("Washers");

            builder
                .Property(w => w.Id)
                .ValueGeneratedOnAdd();
            
            builder
                .HasOne(w => w.WashCompany)
                .WithMany(wc => wc.Washers)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}