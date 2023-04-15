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
                .HasOne(Order => Order.Washer)
                .WithMany(Washer => Washer.Orders)
                .HasForeignKey(Order => Order.WasherId);
                
            
            builder
                .HasOne(order => order.WashCompany)
                .WithMany(WashCompany => WashCompany.Orders)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(Order => Order.WashCompanyId);
            
            builder
                .HasOne(order => order.Service)
                .WithMany(service => service.Orders)
                .HasForeignKey(order => order.ServiceId);
        }
    }
}