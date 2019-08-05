namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl63 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderPaid", "ProjectID", "dbo.Project");
            DropIndex("dbo.OrderPaid", new[] { "ProjectID" });
            RenameColumn(table: "dbo.OrderPaid", name: "ProjectID", newName: "Project_ID");
            AddColumn("dbo.OrderPaid", "HouseTypeShowID", c => c.Long(nullable: false));
            AlterColumn("dbo.OrderPaid", "Project_ID", c => c.Long());
            CreateIndex("dbo.OrderPaid", "Project_ID");
            AddForeignKey("dbo.OrderPaid", "Project_ID", "dbo.Project", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderPaid", "Project_ID", "dbo.Project");
            DropIndex("dbo.OrderPaid", new[] { "Project_ID" });
            AlterColumn("dbo.OrderPaid", "Project_ID", c => c.Long(nullable: false));
            DropColumn("dbo.OrderPaid", "HouseTypeShowID");
            RenameColumn(table: "dbo.OrderPaid", name: "Project_ID", newName: "ProjectID");
            CreateIndex("dbo.OrderPaid", "ProjectID");
            AddForeignKey("dbo.OrderPaid", "ProjectID", "dbo.Project", "ID", cascadeDelete: true);
        }
    }
}
