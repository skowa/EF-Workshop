namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_orders", "Item_Id", "dbo.tbl_items");
            DropIndex("dbo.tbl_orders", new[] { "Item_Id" });
            DropPrimaryKey("dbo.tbl_order_items");
            AddColumn("dbo.tbl_order_items", "cln_item_qty", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tbl_order_items", new[] { "cln_item_id", "cln_order_id" });
            DropColumn("dbo.tbl_orders", "Item_Id");

            this.Sql(@"UPDATE dbo.tbl_order_items SET cln_item_qty = 4 WHERE cln_item_id = 563 AND cln_order_id = 125");
            this.Sql(@"UPDATE dbo.tbl_order_items SET cln_item_qty = 500 WHERE cln_item_id = 563 AND cln_order_id = 126");
            this.Sql(@"UPDATE dbo.tbl_order_items SET cln_item_qty = 32 WHERE cln_item_id = 851 AND cln_order_id = 125");
            this.Sql(@"UPDATE dbo.tbl_order_items SET cln_item_qty = 5 WHERE cln_item_id = 652 AND cln_order_id = 125");
            this.Sql(@"UPDATE dbo.tbl_order_items SET cln_item_qty = 750 WHERE cln_item_id = 652 AND cln_order_id = 126");
        }

        public override void Down()
        {
            AddColumn("dbo.tbl_orders", "Item_Id", c => c.Int());
            DropPrimaryKey("dbo.tbl_order_items");
            DropColumn("dbo.tbl_order_items", "cln_item_qty");
            AddPrimaryKey("dbo.tbl_order_items", new[] { "cln_order_id", "cln_item_id" });
            CreateIndex("dbo.tbl_orders", "Item_Id");
            AddForeignKey("dbo.tbl_orders", "Item_Id", "dbo.tbl_items", "cln_item_id");
        }
    }
}
