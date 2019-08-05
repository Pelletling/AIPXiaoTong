namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberManagement", "MerchantID", c => c.Long());
            CreateIndex("dbo.MemberManagement", "MerchantID");
            AddForeignKey("dbo.MemberManagement", "MerchantID", "dbo.Merchant", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberManagement", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.MemberManagement", new[] { "MerchantID" });
            DropColumn("dbo.MemberManagement", "MerchantID");
        }
    }
}
