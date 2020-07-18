namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        City_Id = c.Int(nullable: false, identity: true),
                        City_Name = c.String(nullable: false),
                        City_Image = c.String(),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.City_Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Hospital_id = c.Int(nullable: false, identity: true),
                        Hospital_Name = c.String(),
                        City_Id = c.Int(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        URL = c.String(nullable: false),
                        Image1 = c.String(nullable: false),
                        Image2 = c.String(nullable: false),
                        Image3 = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        Open = c.String(),
                        Close = c.String(),
                    })
                .PrimaryKey(t => t.Hospital_id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Hotel_id = c.Int(nullable: false, identity: true),
                        Hotel_Name = c.String(),
                        City_Id = c.Int(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        URL = c.String(nullable: false),
                        Image1 = c.String(nullable: false),
                        Image2 = c.String(nullable: false),
                        Image3 = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        Open = c.String(),
                        Close = c.String(),
                    })
                .PrimaryKey(t => t.Hotel_id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Restaurant_id = c.Int(nullable: false, identity: true),
                        Restaurant_Name = c.String(),
                        City_Id = c.Int(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        URL = c.String(nullable: false),
                        Image1 = c.String(nullable: false),
                        Image2 = c.String(nullable: false),
                        Image3 = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        Open = c.String(),
                        Close = c.String(),
                    })
                .PrimaryKey(t => t.Restaurant_id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        School_id = c.Int(nullable: false, identity: true),
                        School_Name = c.String(),
                        City_Id = c.Int(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        URL = c.String(nullable: false),
                        Image1 = c.String(nullable: false),
                        Image2 = c.String(nullable: false),
                        Image3 = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        Open = c.String(),
                        Close = c.String(),
                    })
                .PrimaryKey(t => t.School_id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.Int(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Schools", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Restaurants", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Hotels", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Hospitals", "City_Id", "dbo.Cities");
            DropIndex("dbo.Schools", new[] { "City_Id" });
            DropIndex("dbo.Restaurants", new[] { "City_Id" });
            DropIndex("dbo.Hotels", new[] { "City_Id" });
            DropIndex("dbo.Hospitals", new[] { "City_Id" });
            DropIndex("dbo.Cities", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Schools");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Hotels");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Cities");
        }
    }
}
