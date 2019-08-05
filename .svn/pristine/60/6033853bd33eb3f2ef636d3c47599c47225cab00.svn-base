namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectManagement", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.ProjectManagement", new[] { "MerchantID" });
            AddColumn("dbo.ProjectManagement", "DistrictManagementID", c => c.Long());
            AlterColumn("dbo.ProjectManagement", "MerchantID", c => c.Long());
            CreateIndex("dbo.ProjectManagement", "MerchantID");
            CreateIndex("dbo.ProjectManagement", "DistrictManagementID");
            AddForeignKey("dbo.ProjectManagement", "DistrictManagementID", "dbo.DistrictManagement", "ID");
            AddForeignKey("dbo.ProjectManagement", "MerchantID", "dbo.Merchant", "ID");
            DropColumn("dbo.ProjectManagement", "DistrictName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectManagement", "DistrictName", c => c.String(maxLength: 32));
            DropForeignKey("dbo.ProjectManagement", "MerchantID", "dbo.Merchant");
            DropForeignKey("dbo.ProjectManagement", "DistrictManagementID", "dbo.DistrictManagement");
            DropIndex("dbo.ProjectManagement", new[] { "DistrictManagementID" });
            DropIndex("dbo.ProjectManagement", new[] { "MerchantID" });
            AlterColumn("dbo.ProjectManagement", "MerchantID", c => c.Long(nullable: false));
            DropColumn("dbo.ProjectManagement", "DistrictManagementID");
            CreateIndex("dbo.ProjectManagement", "MerchantID");
            AddForeignKey("dbo.ProjectManagement", "MerchantID", "dbo.Merchant", "ID", cascadeDelete: true);
        }
    }
}
