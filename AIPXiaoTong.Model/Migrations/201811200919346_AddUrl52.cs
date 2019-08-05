namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl52 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankCard", "Verified", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BankCard", "Verified");
        }
    }
}
