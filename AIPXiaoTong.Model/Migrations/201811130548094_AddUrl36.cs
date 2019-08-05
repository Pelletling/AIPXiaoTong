namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl36 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectManagement", "MerchantID", "dbo.Merchant");
            DropForeignKey("dbo.Equipment", "MerchantID", "dbo.Merchant");
            DropForeignKey("dbo.OrderBooking", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.OrderBooking", "ProjectManagementID", "dbo.ProjectManagement");
            DropForeignKey("dbo.OrderHousePayment", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.OrderHousePayment", "ProjectManagementID", "dbo.ProjectManagement");
            DropForeignKey("dbo.OrderPaid", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.OrderPaid", "ProjectManagementID", "dbo.ProjectManagement");
            DropIndex("dbo.ProjectManagement", new[] { "MerchantID" });
            DropIndex("dbo.Equipment", new[] { "MerchantID" });
            DropIndex("dbo.OrderBooking", new[] { "ProjectManagementID" });
            DropIndex("dbo.OrderBooking", new[] { "EmployeeID" });
            DropIndex("dbo.OrderHousePayment", new[] { "ProjectManagementID" });
            DropIndex("dbo.OrderHousePayment", new[] { "EmployeeID" });
            DropIndex("dbo.OrderPaid", new[] { "ProjectManagementID" });
            DropIndex("dbo.OrderPaid", new[] { "EmployeeID" });
            AlterColumn("dbo.ProjectManagement", "MerchantID", c => c.Long(nullable: false));
            AlterColumn("dbo.ProjectManagement", "ProjectImage", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ProjectManagement", "ProvinceCode", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.ProjectManagement", "CityCode", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Equipment", "MerchantID", c => c.Long(nullable: false));
            AlterColumn("dbo.OrderBooking", "ProjectManagementID", c => c.Long(nullable: false));
            AlterColumn("dbo.OrderBooking", "EmployeeID", c => c.Long(nullable: false));
            AlterColumn("dbo.OrderBooking", "Mobile", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.OrderBooking", "IDNumber", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.OrderHousePayment", "ProjectManagementID", c => c.Long(nullable: false));
            AlterColumn("dbo.OrderHousePayment", "EmployeeID", c => c.Long(nullable: false));
            AlterColumn("dbo.OrderPaid", "ProjectManagementID", c => c.Long(nullable: false));
            AlterColumn("dbo.OrderPaid", "EmployeeID", c => c.Long(nullable: false));
            CreateIndex("dbo.ProjectManagement", "MerchantID");
            CreateIndex("dbo.Equipment", "MerchantID");
            CreateIndex("dbo.OrderBooking", "ProjectManagementID");
            CreateIndex("dbo.OrderBooking", "EmployeeID");
            CreateIndex("dbo.OrderHousePayment", "ProjectManagementID");
            CreateIndex("dbo.OrderHousePayment", "EmployeeID");
            CreateIndex("dbo.OrderPaid", "ProjectManagementID");
            CreateIndex("dbo.OrderPaid", "EmployeeID");
            AddForeignKey("dbo.ProjectManagement", "MerchantID", "dbo.Merchant", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Equipment", "MerchantID", "dbo.Merchant", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderBooking", "EmployeeID", "dbo.Employee", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderBooking", "ProjectManagementID", "dbo.ProjectManagement", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderHousePayment", "EmployeeID", "dbo.Employee", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderHousePayment", "ProjectManagementID", "dbo.ProjectManagement", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderPaid", "EmployeeID", "dbo.Employee", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderPaid", "ProjectManagementID", "dbo.ProjectManagement", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderPaid", "ProjectManagementID", "dbo.ProjectManagement");
            DropForeignKey("dbo.OrderPaid", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.OrderHousePayment", "ProjectManagementID", "dbo.ProjectManagement");
            DropForeignKey("dbo.OrderHousePayment", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.OrderBooking", "ProjectManagementID", "dbo.ProjectManagement");
            DropForeignKey("dbo.OrderBooking", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Equipment", "MerchantID", "dbo.Merchant");
            DropForeignKey("dbo.ProjectManagement", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.OrderPaid", new[] { "EmployeeID" });
            DropIndex("dbo.OrderPaid", new[] { "ProjectManagementID" });
            DropIndex("dbo.OrderHousePayment", new[] { "EmployeeID" });
            DropIndex("dbo.OrderHousePayment", new[] { "ProjectManagementID" });
            DropIndex("dbo.OrderBooking", new[] { "EmployeeID" });
            DropIndex("dbo.OrderBooking", new[] { "ProjectManagementID" });
            DropIndex("dbo.Equipment", new[] { "MerchantID" });
            DropIndex("dbo.ProjectManagement", new[] { "MerchantID" });
            AlterColumn("dbo.OrderPaid", "EmployeeID", c => c.Long());
            AlterColumn("dbo.OrderPaid", "ProjectManagementID", c => c.Long());
            AlterColumn("dbo.OrderHousePayment", "EmployeeID", c => c.Long());
            AlterColumn("dbo.OrderHousePayment", "ProjectManagementID", c => c.Long());
            AlterColumn("dbo.OrderBooking", "IDNumber", c => c.String(maxLength: 32));
            AlterColumn("dbo.OrderBooking", "Mobile", c => c.String(maxLength: 11));
            AlterColumn("dbo.OrderBooking", "EmployeeID", c => c.Long());
            AlterColumn("dbo.OrderBooking", "ProjectManagementID", c => c.Long());
            AlterColumn("dbo.Equipment", "MerchantID", c => c.Long());
            AlterColumn("dbo.ProjectManagement", "CityCode", c => c.String(maxLength: 8));
            AlterColumn("dbo.ProjectManagement", "ProvinceCode", c => c.String(maxLength: 8));
            AlterColumn("dbo.ProjectManagement", "ProjectImage", c => c.String(maxLength: 128));
            AlterColumn("dbo.ProjectManagement", "MerchantID", c => c.Long());
            CreateIndex("dbo.OrderPaid", "EmployeeID");
            CreateIndex("dbo.OrderPaid", "ProjectManagementID");
            CreateIndex("dbo.OrderHousePayment", "EmployeeID");
            CreateIndex("dbo.OrderHousePayment", "ProjectManagementID");
            CreateIndex("dbo.OrderBooking", "EmployeeID");
            CreateIndex("dbo.OrderBooking", "ProjectManagementID");
            CreateIndex("dbo.Equipment", "MerchantID");
            CreateIndex("dbo.ProjectManagement", "MerchantID");
            AddForeignKey("dbo.OrderPaid", "ProjectManagementID", "dbo.ProjectManagement", "ID");
            AddForeignKey("dbo.OrderPaid", "EmployeeID", "dbo.Employee", "ID");
            AddForeignKey("dbo.OrderHousePayment", "ProjectManagementID", "dbo.ProjectManagement", "ID");
            AddForeignKey("dbo.OrderHousePayment", "EmployeeID", "dbo.Employee", "ID");
            AddForeignKey("dbo.OrderBooking", "ProjectManagementID", "dbo.ProjectManagement", "ID");
            AddForeignKey("dbo.OrderBooking", "EmployeeID", "dbo.Employee", "ID");
            AddForeignKey("dbo.Equipment", "MerchantID", "dbo.Merchant", "ID");
            AddForeignKey("dbo.ProjectManagement", "MerchantID", "dbo.Merchant", "ID");
        }
    }
}
