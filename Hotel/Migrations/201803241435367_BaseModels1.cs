namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseModels1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApartmentModels", newName: "Apartments");
            RenameTable(name: "dbo.ApTypeModels", newName: "ApTypes");
            RenameTable(name: "dbo.ReservationModels", newName: "Reservations");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Reservations", newName: "ReservationModels");
            RenameTable(name: "dbo.ApTypes", newName: "ApTypeModels");
            RenameTable(name: "dbo.Apartments", newName: "ApartmentModels");
        }
    }
}
