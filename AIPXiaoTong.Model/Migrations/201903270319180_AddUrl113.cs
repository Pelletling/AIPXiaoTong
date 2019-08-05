namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl113 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "MerchantMember_ID", c => c.Long());
            CreateIndex("dbo.Member", "MerchantMember_ID");
            AddForeignKey("dbo.Member", "MerchantMember_ID", "dbo.MerchantMember", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Member", "MerchantMember_ID", "dbo.MerchantMember");
            DropIndex("dbo.Member", new[] { "MerchantMember_ID" });
            DropColumn("dbo.Member", "MerchantMember_ID");
        }
    }
}
