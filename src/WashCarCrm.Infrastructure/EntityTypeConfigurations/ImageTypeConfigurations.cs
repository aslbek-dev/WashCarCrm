using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.EntityTypeConfigurations
{
    public class ImageTypeConfigurations : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");

            builder
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();
            builder
                .HasOne(i => i.WashCompany)
                .WithOne(wc => wc.Image)
                .HasForeignKey<WashCompany>(wc => wc.ImageId);
            
            builder
                .HasOne(i => i.Washer)
                .WithOne(w => w.Image)
                .HasForeignKey<Washer>(w => w.ImageId);
        }
    }
}