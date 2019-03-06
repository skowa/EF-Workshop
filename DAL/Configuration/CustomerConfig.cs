using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class CustomerConfig : EntityTypeConfiguration<Customer>
    {
        public CustomerConfig()
        {
            this.ToTable("tbl_customers").HasKey(customer => customer.Id);
            this.Property(customer => customer.Id).HasColumnName("cln_customer_id");
            this.Property(customer => customer.Name).HasColumnName("cln_customer_name");
            this.Property(customer => customer.Address).HasColumnName("cln_customer_address");
            this.Property(customer => customer.City).HasColumnName("cln_customer_city");
            this.Property(customer => customer.State).HasColumnName("cln_customer_state");

            this.HasMany(customer => customer.Orders).WithRequired(order => order.Customer)
                .HasForeignKey(order => order.CustomerId);
        }
    }
}