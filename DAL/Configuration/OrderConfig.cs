﻿using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class OrderConfig : EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            this.ToTable("tbl_orders").HasKey(order => order.Id);
            this.Property(order => order.Id).HasColumnName("cln_order_id");
            this.Property(order => order.Date).HasColumnName("cln_order_date");
            this.Property(order => order.CustomerId).HasColumnName("cln_customer_id");

            this.HasMany(order => order.OrderItems).WithRequired(orderItem => orderItem.Order)
                .HasForeignKey(orderItem => orderItem.OrderId);
        }
    }
}