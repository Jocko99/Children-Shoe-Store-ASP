using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDataAccess.Configuration
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLines>
    {
        public void Configure(EntityTypeBuilder<OrderLines> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Size).IsRequired();

            builder.HasOne(x => x.Order).WithMany(x => x.OrderLines).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ProductSize).WithMany(x => x.OrderLines).HasForeignKey(x => x.ProductSizeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
