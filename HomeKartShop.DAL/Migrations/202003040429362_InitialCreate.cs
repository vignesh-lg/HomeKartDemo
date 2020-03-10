namespace HomeKartShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        RegistrationNumber = c.String(),
                        PinCode = c.Int(nullable: false),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        UserName = c.String(maxLength: 450),
                        gender = c.String(),
                        Search = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.UserName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "UserName" });
            DropTable("dbo.User");
        }
    }
}
