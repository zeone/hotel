namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedSuname : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reservations", "Suname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "Suname", c => c.String(nullable: false));
        }
    }
}
