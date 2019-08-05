namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl76 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Member", "FreezeBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Member", "FreezeBalance");
            DropColumn("dbo.Member", "Balance");
        }
    }
}
