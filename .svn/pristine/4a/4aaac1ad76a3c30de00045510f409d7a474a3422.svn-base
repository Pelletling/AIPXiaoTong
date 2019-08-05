namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl67 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Preferences", new[] { "MerchantInfo" });
            DropColumn("dbo.Preferences", "MerchantInfo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Preferences", "MerchantInfo", c => c.String(nullable: false, maxLength: 32));
            CreateIndex("dbo.Preferences", "MerchantInfo", unique: true);
        }
    }
}
