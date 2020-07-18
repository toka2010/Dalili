namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationv1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "User_Id", "dbo.Users");
            DropIndex("dbo.Cities", new[] { "User_Id" });
            DropColumn("dbo.Cities", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "User_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Cities", "User_Id");
            AddForeignKey("dbo.Cities", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
