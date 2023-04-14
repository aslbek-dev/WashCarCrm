using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.EntityTypeConfigurations
{
    public class OrderTypeConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder
                .Property(order => order.Id)
                .ValueGeneratedOnAdd();
            
            builder
                .HasMany(Order => Order.Washers)
                .WithMany(Washer => Washer.Orders);
            
            builder
                .HasOne(order => order.WashCompany)
                .WithMany(WashCompany => WashCompany.Orders);
            
            builder
                .HasMany(order => order.Services)
                .WithMany(service => service.Orders);
        }
    }
}