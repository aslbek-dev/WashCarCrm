using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.EntityTypeConfigurations
{
    public class WashCompanyTypeConfigurations : IEntityTypeConfiguration<WashCompany>
    {
        public void Configure(EntityTypeBuilder<WashCompany> builder)
        {
            builder.ToTable("WashCompanies");

            builder
                .Property(WashCompany => WashCompany.Id)
                .ValueGeneratedOnAdd();
                
            builder
                .Property(w => w.Name)
                .HasMaxLength(120);
            
            builder
                .HasOne(wc => wc.Image)
                .WithOne(i => i.WashCompany);
        }
    }
}