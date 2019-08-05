namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeDepartment", "MerchantID", c => c.Long(nullable: false));
            AddColumn("dbo.EmployeeRole", "MerchantID", c => c.Long(nullable: false));
            CreateIndex("dbo.EmployeeDepartment", "MerchantID");
            CreateIndex("dbo.EmployeeRole", "MerchantID");
            AddForeignKey("dbo.EmployeeDepartment", "MerchantID", "dbo.Merchant", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeRole", "MerchantID", "dbo.Merchant", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeRole", "MerchantID", "dbo.Merchant");
            DropForeignKey("dbo.EmployeeDepartment", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.EmployeeRole", new[] { "MerchantID" });
            DropIndex("dbo.EmployeeDepartment", new[] { "MerchantID" });
            DropColumn("dbo.EmployeeRole", "MerchantID");
            DropColumn("dbo.EmployeeDepartment", "MerchantID");
        }
    }
}
