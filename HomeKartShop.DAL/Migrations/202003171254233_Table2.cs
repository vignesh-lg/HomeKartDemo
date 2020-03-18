namespace HomeKartShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarouselSlider", "FileName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.CarouselSlider", "FilePath", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.City", "CityName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.State", "StateName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Inventory", "ProductName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Inventory", "Quantity", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Inventory", "Category", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.ProductCategories", "CategoryName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.ProductCategories", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterStoredProcedure(
                "dbo.CarouselSlider_Insert",
                p => new
                    {
                        FileName = p.String(maxLength: 100),
                        FileSize = p.Int(),
                        FilePath = p.String(maxLength: 100),
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
            
            AlterStoredProcedure(
                "dbo.CarouselSlider_Update",
                p => new
                    {
                        ID = p.Int(),
                        FileName = p.String(maxLength: 100),
                        FileSize = p.Int(),
                        FilePath = p.String(maxLength: 100),
                    },
                body:
                    @"UPDATE [dbo].[CarouselSlider]
                      SET [FileName] = @FileName, [FileSize] = @FileSize, [FilePath] = @FilePath
                      WHERE ([ID] = @ID)"
            );
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategories", "Description", c => c.String());
            AlterColumn("dbo.ProductCategories", "CategoryName", c => c.String());
            AlterColumn("dbo.Inventory", "Category", c => c.String());
            AlterColumn("dbo.Inventory", "Quantity", c => c.String());
            AlterColumn("dbo.Inventory", "ProductName", c => c.String());
            AlterColumn("dbo.State", "StateName", c => c.String());
            AlterColumn("dbo.City", "CityName", c => c.String());
            AlterColumn("dbo.CarouselSlider", "FilePath", c => c.String());
            AlterColumn("dbo.CarouselSlider", "FileName", c => c.String());
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
