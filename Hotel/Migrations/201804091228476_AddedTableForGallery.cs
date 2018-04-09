namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTableForGallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        ImgId = c.Int(nullable: false, identity: true),
                        ImgName = c.String(),
                    })
                .PrimaryKey(t => t.ImgId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Galleries");
        }
    }
}
