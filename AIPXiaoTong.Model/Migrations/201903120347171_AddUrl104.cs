namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl104 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AccountPingAn", new[] { "BankCardNumber" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.AccountPingAn", "BankCardNumber", unique: true);
        }
    }
}
