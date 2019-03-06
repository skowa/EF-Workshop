﻿using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
