namespace HomeKartShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.User", new[] { "UserName" });
            AlterColumn("dbo.User", "CustomerFirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "CustomerSecondName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "State", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "City", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "Address", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.User", "RegistrationNumber", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "gender", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.User", "Email", unique: true);
            CreateIndex("dbo.User", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "UserName" });
            DropIndex("dbo.User", new[] { "Email" });
            AlterColumn("dbo.User", "gender", c => c.String());
            AlterColumn("dbo.User", "UserName", c => c.String(maxLength: 450));
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "RegistrationNumber", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String(maxLength: 450));
            AlterColumn("dbo.User", "Address", c => c.String());
            AlterColumn("dbo.User", "City", c => c.String());
            AlterColumn("dbo.User", "State", c => c.String());
            AlterColumn("dbo.User", "CustomerSecondName", c => c.String());
            AlterColumn("dbo.User", "CustomerFirstName", c => c.String());
            CreateIndex("dbo.User", "UserName", unique: true);
            CreateIndex("dbo.User", "Email", unique: true);
        }
    }
}
