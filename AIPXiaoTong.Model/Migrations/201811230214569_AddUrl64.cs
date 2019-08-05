namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl64 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderPaid", "Project_ID", "dbo.Project");
            DropIndex("dbo.OrderPaid", new[] { "Project_ID" });
            CreateIndex("dbo.OrderPaid", "HouseTypeShowID");
            AddForeignKey("dbo.OrderPaid", "HouseTypeShowID", "dbo.HouseTypeShow", "ID", cascadeDelete: true);
            DropColumn("dbo.OrderPaid", "Project_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderPaid", "Project_ID", c => c.Long());
            DropForeignKey("dbo.OrderPaid", "HouseTypeShowID", "dbo.HouseTypeShow");
            DropIndex("dbo.OrderPaid", new[] { "HouseTypeShowID" });
            CreateIndex("dbo.OrderPaid", "Project_ID");
            AddForeignKey("dbo.OrderPaid", "Project_ID", "dbo.Project", "ID");
        }
    }
}
