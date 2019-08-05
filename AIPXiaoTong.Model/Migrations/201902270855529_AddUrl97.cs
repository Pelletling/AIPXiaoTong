namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl97 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountPingAn", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AccountPingAn", "FreezeBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountPingAn", "FreezeBalance");
            DropColumn("dbo.AccountPingAn", "Balance");
        }
    }
}
