namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl79 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderPaid", "HouseTypeShowID", "dbo.HouseTypeShow");
            DropIndex("dbo.OrderPaid", new[] { "HouseTypeShowID" });
            //AddColumn("dbo.OrderPaid", "ProjectID", c => c.Long(nullable: false));
            AddColumn("dbo.Project", "ProjectName", c => c.String(nullable: false, maxLength: 32));
            //CreateIndex("dbo.OrderPaid", "ProjectID");
            //AddForeignKey("dbo.OrderPaid", "ProjectID", "dbo.Project", "ID", cascadeDelete: true);
            DropColumn("dbo.OrderPaid", "HouseTypeShowID");
            DropColumn("dbo.Project", "ProjetName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Project", "ProjetName", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.OrderPaid", "HouseTypeShowID", c => c.Long(nullable: false));
            DropForeignKey("dbo.OrderPaid", "ProjectID", "dbo.Project");
            DropIndex("dbo.OrderPaid", new[] { "ProjectID" });
            DropColumn("dbo.Project", "ProjectName");
            DropColumn("dbo.OrderPaid", "ProjectID");
            CreateIndex("dbo.OrderPaid", "HouseTypeShowID");
            AddForeignKey("dbo.OrderPaid", "HouseTypeShowID", "dbo.HouseTypeShow", "ID", cascadeDelete: true);
        }
    }
}
