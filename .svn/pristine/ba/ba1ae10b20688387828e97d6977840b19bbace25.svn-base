namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl55 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "MerchantID", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Member", "MerchantID");
        }
    }
}
