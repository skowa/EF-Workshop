using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class OrderItemConfig : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemConfig()
        {
            this.ToTable("tbl_order_items").HasKey(orderItem => new {orderItem.ItemId, orderItem.OrderId});
            this.Property(orderItem => orderItem.ItemId).HasColumnName("cln_item_id");
            this.Property(orderItem => orderItem.OrderId).HasColumnName("cln_order_id");
            this.Property(order => order.Quantity).HasColumnName("cln_item_qty");
        }
    }
}