namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl63 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderPaid", "Project_ID", "dbo.Project");
            DropIndex("dbo.OrderPaid", new[] { "Project_ID" });
            RenameColumn(table: "dbo.OrderPaid", name: "Project_ID", newName: "ProjectID");
            AlterColumn("dbo.OrderPaid", "ProjectID", c => c.Long(nullable: false));
            CreateIndex("dbo.OrderPaid", "ProjectID");
            AddForeignKey("dbo.OrderPaid", "ProjectID", "dbo.Project", "ID", cascadeDelete: true);
            DropColumn("dbo.OrderPaid", "HouseTypeShowID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderPaid", "HouseTypeShowID", c => c.Long(nullable: false));
            DropForeignKey("dbo.OrderPaid", "ProjectID", "dbo.Project");
            DropIndex("dbo.OrderPaid", new[] { "ProjectID" });
            AlterColumn("dbo.OrderPaid", "ProjectID", c => c.Long());
            RenameColumn(table: "dbo.OrderPaid", name: "ProjectID", newName: "Project_ID");
            CreateIndex("dbo.OrderPaid", "Project_ID");
            AddForeignKey("dbo.OrderPaid", "Project_ID", "dbo.Project", "ID");
        }
    }
}
