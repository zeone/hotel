namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedChildrenToReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ChildrenCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "ChildrenCount");
        }
    }
}
