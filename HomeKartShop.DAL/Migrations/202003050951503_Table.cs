namespace HomeKartShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        StateId_StateId = c.Int(),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.State", t => t.StateId_StateId)
                .Index(t => t.StateId_StateId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.City", "StateId_StateId", "dbo.State");
            DropIndex("dbo.City", new[] { "StateId_StateId" });
            DropTable("dbo.State");
            DropTable("dbo.City");
        }
    }
}
