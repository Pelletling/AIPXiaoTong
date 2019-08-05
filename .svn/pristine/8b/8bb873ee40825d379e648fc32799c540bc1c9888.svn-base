namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl64 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderPaid", "HouseTypeShowID", c => c.Long(nullable: false));
            CreateIndex("dbo.OrderPaid", "HouseTypeShowID");
            AddForeignKey("dbo.OrderPaid", "HouseTypeShowID", "dbo.HouseTypeShow", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderPaid", "HouseTypeShowID", "dbo.HouseTypeShow");
            DropIndex("dbo.OrderPaid", new[] { "HouseTypeShowID" });
            DropColumn("dbo.OrderPaid", "HouseTypeShowID");
        }
    }
}
