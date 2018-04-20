namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailIsnotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "Email", c => c.String(nullable: false));
        }
    }
}
