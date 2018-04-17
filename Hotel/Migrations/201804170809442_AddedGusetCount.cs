namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddedGusetCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "GuestCount", c => c.Int(nullable: false, defaultValue: 1));
        }

        public override void Down()
        {
            DropColumn("dbo.Reservations", "GuestCount");
        }
    }
}
