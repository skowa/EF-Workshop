using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class ItemConfig : EntityTypeConfiguration<Item>
    {
        public ItemConfig()
        {
            this.ToTable("tbl_items").HasKey(item => item.Id);
            this.Property(item => item.Id).HasColumnName("cln_item_id");
            this.Property(item => item.Description).HasColumnName("cln_item_description");
            this.Property(item => item.Price).HasColumnName("cln_item_price");

            this.HasMany(item => item.OrderItems).WithRequired(orderItem => orderItem.Item)
                .HasForeignKey(item => item.ItemId);
        }
    }
}