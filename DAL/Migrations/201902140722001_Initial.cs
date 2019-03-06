namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_items",
                c => new
                    {
                        cln_item_id = c.Int(nullable: false, identity: true),
                        cln_item_description = c.String(),
                        cln_item_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.cln_item_id);

            this.Sql(@"SET IDENTITY_INSERT dbo.tbl_items ON 
                 INSERT INTO tbl_items (cln_item_id, cln_item_description, cln_item_price) VALUES
                 (563, '56'' Blue Freen', 3.5),
                 (652, '3'' Red Freen', 12.0),
                 (851, 'Spline End (Xtra Large)', 0.25)
                SET IDENTITY_INSERT dbo.tbl_items OFF");
        }

        public override void Down()
        {
            DropTable("dbo.tbl_items");
        }
    }
}
