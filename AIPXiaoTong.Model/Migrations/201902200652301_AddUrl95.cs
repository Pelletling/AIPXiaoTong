namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl95 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountPingAn", "BankCardNumber", c => c.String(nullable: false, maxLength: 32));
            CreateIndex("dbo.AccountPingAn", "BankCardNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.AccountPingAn", new[] { "BankCardNumber" });
            DropColumn("dbo.AccountPingAn", "BankCardNumber");
        }
    }
}
