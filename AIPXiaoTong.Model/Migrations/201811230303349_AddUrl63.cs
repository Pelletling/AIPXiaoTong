namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl63 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.OrderPaid", "Project_ID", "dbo.Project");
            //DropIndex("dbo.OrderPaid", new[] { "Project_ID" });
            //DropColumn("dbo.OrderPaid", "HouseTypeShowID");
            //DropColumn("dbo.OrderPaid", "Project_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderPaid", "Project_ID", c => c.Long());
            AddColumn("dbo.OrderPaid", "HouseTypeShowID", c => c.Long(nullable: false));
            CreateIndex("dbo.OrderPaid", "Project_ID");
            AddForeignKey("dbo.OrderPaid", "Project_ID", "dbo.Project", "ID");
        }
    }
}
