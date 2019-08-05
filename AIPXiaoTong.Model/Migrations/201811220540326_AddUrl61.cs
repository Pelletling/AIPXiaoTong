namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl61 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectManagement", newName: "Project");
            RenameColumn(table: "dbo.HouseTypeShow", name: "ProjectManagementID", newName: "ProjectID");
            RenameColumn(table: "dbo.OrderBooking", name: "ProjectManagementID", newName: "ProjectID");
            RenameColumn(table: "dbo.OrderHousePayment", name: "ProjectManagementID", newName: "ProjectID");
            RenameColumn(table: "dbo.OrderPaid", name: "ProjectManagementID", newName: "ProjectID");
            RenameIndex(table: "dbo.HouseTypeShow", name: "IX_ProjectManagementID", newName: "IX_ProjectID");
            RenameIndex(table: "dbo.OrderBooking", name: "IX_ProjectManagementID", newName: "IX_ProjectID");
            RenameIndex(table: "dbo.OrderHousePayment", name: "IX_ProjectManagementID", newName: "IX_ProjectID");
            RenameIndex(table: "dbo.OrderPaid", name: "IX_ProjectManagementID", newName: "IX_ProjectID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.OrderPaid", name: "IX_ProjectID", newName: "IX_ProjectManagementID");
            RenameIndex(table: "dbo.OrderHousePayment", name: "IX_ProjectID", newName: "IX_ProjectManagementID");
            RenameIndex(table: "dbo.OrderBooking", name: "IX_ProjectID", newName: "IX_ProjectManagementID");
            RenameIndex(table: "dbo.HouseTypeShow", name: "IX_ProjectID", newName: "IX_ProjectManagementID");
            RenameColumn(table: "dbo.OrderPaid", name: "ProjectID", newName: "ProjectManagementID");
            RenameColumn(table: "dbo.OrderHousePayment", name: "ProjectID", newName: "ProjectManagementID");
            RenameColumn(table: "dbo.OrderBooking", name: "ProjectID", newName: "ProjectManagementID");
            RenameColumn(table: "dbo.HouseTypeShow", name: "ProjectID", newName: "ProjectManagementID");
            RenameTable(name: "dbo.Project", newName: "ProjectManagement");
        }
    }
}
