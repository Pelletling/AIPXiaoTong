namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl66 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Preferences", "MerchantUrl");
            DropColumn("dbo.Preferences", "SecretKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Preferences", "SecretKey", c => c.String(maxLength: 64));
            AddColumn("dbo.Preferences", "MerchantUrl", c => c.String());
        }
    }
}
