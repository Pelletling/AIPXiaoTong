namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl22 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HouseTypeShow", "HouseTypeNameID", "dbo.HouseTypeName");
            DropIndex("dbo.HouseTypeShow", new[] { "HouseTypeNameID" });
            AddColumn("dbo.HouseTypeShow", "HouseTypeName", c => c.String(nullable: false, maxLength: 32));
            DropColumn("dbo.HouseTypeShow", "HouseTypeNameID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HouseTypeShow", "HouseTypeNameID", c => c.Long(nullable: false));
            DropColumn("dbo.HouseTypeShow", "HouseTypeName");
            CreateIndex("dbo.HouseTypeShow", "HouseTypeNameID");
            AddForeignKey("dbo.HouseTypeShow", "HouseTypeNameID", "dbo.HouseTypeName", "ID", cascadeDelete: true);
        }
    }
}
