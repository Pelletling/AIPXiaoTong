namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl114 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Member", "MerchantMember_ID", "dbo.MerchantMember");
            DropIndex("dbo.Member", new[] { "MerchantMember_ID" });
            CreateIndex("dbo.MerchantMember", "MemberID");
            AddForeignKey("dbo.MerchantMember", "MemberID", "dbo.Member", "ID", cascadeDelete: true);
            DropColumn("dbo.Member", "MerchantMember_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Member", "MerchantMember_ID", c => c.Long());
            DropForeignKey("dbo.MerchantMember", "MemberID", "dbo.Member");
            DropIndex("dbo.MerchantMember", new[] { "MemberID" });
            CreateIndex("dbo.Member", "MerchantMember_ID");
            AddForeignKey("dbo.Member", "MerchantMember_ID", "dbo.MerchantMember", "ID");
        }
    }
}
