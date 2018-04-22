namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ChangesInApTypePrices : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApTypes", "OnePersonPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValue: 0));
            AddColumn("dbo.ApTypes", "TwoPersonPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValue: 0));
            AddColumn("dbo.ApTypes", "ThreePersonPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValue: 0));
            AddColumn("dbo.ApTypes", "FourPersonPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValue: 0));
            DropColumn("dbo.ApTypes", "Price");
        }

        public override void Down()
        {
            AddColumn("dbo.ApTypes", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ApTypes", "FourPersonPrice");
            DropColumn("dbo.ApTypes", "ThreePersonPrice");
            DropColumn("dbo.ApTypes", "TwoPersonPrice");
            DropColumn("dbo.ApTypes", "OnePersonPrice");
        }
    }
}
