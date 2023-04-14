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
                .HasOne(WashCompany => WashCompany.Image)
                .WithOne(Image => Image.WashCompany);
                
            builder
                .Property(w => w.Name)
                .HasMaxLength(120);
        }
    }
}