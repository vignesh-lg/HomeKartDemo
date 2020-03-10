namespace HomeKartShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarouselSlider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileSize = c.Int(nullable: false),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarouselSlider");
        }
    }
}
