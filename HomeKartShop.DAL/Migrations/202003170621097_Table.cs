namespace HomeKartShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarouselSlider",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileSize = c.Int(nullable: false),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Int(nullable: false),
                        Quantity = c.String(),
                        Category = c.String(),
                        TotalStock = c.Int(nullable: false),
                        TotalSold = c.Int(nullable: false),
                        Remaining = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        CustomerFirstName = c.String(),
                        CustomerSecondName = c.String(),
                        State = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        CellNumber = c.Long(nullable: false),
                        Email = c.String(maxLength: 450),
                        DateOfBirth = c.DateTime(nullable: false),
                        RegistrationNumber = c.String(),
                        PinCode = c.Int(nullable: false),
                        Password = c.String(),
                        UserName = c.String(maxLength: 450),
                        gender = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.CellNumber, unique: true)
                .Index(t => t.Email, unique: true)
                .Index(t => t.UserName, unique: true);
            
            CreateStoredProcedure(
                "dbo.CarouselSlider_Insert",
                p => new
                    {
                        FileName = p.String(),
                        FileSize = p.Int(),
                        FilePath = p.String(),
                    },
                body:
                    @"INSERT [dbo].[CarouselSlider]([FileName], [FileSize], [FilePath])
                      VALUES (@FileName, @FileSize, @FilePath)
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [dbo].[CarouselSlider]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [dbo].[CarouselSlider] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );
            
            CreateStoredProcedure(
                "dbo.CarouselSlider_Update",
                p => new
                    {
                        ID = p.Int(),
                        FileName = p.String(),
                        FileSize = p.Int(),
                        FilePath = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[CarouselSlider]
                      SET [FileName] = @FileName, [FileSize] = @FileSize, [FilePath] = @FilePath
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "dbo.CarouselSlider_Delete",
                p => new
                    {
                        ID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[CarouselSlider]
                      WHERE ([ID] = @ID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.CarouselSlider_Delete");
            DropStoredProcedure("dbo.CarouselSlider_Update");
            DropStoredProcedure("dbo.CarouselSlider_Insert");
            DropForeignKey("dbo.City", "StateId_StateId", "dbo.State");
            DropIndex("dbo.User", new[] { "UserName" });
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.User", new[] { "CellNumber" });
            DropIndex("dbo.City", new[] { "StateId_StateId" });
            DropTable("dbo.User");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Inventory");
            DropTable("dbo.State");
            DropTable("dbo.City");
            DropTable("dbo.CarouselSlider");
        }
    }
}
