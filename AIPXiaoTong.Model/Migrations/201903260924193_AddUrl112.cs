namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl112 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountPingAn", "BankCode", c => c.String(maxLength: 32));
            AddColumn("dbo.AccountPingAn", "BankName", c => c.String(maxLength: 32));
            AddColumn("dbo.AccountPingAn", "AccountType", c => c.String(maxLength: 32));
            AddColumn("dbo.AccountPingAn", "Province", c => c.String(maxLength: 32));
            AddColumn("dbo.AccountPingAn", "City", c => c.String(maxLength: 32));
            AddColumn("dbo.AccountPingAn", "AccountProp", c => c.String(maxLength: 32));
            AddColumn("dbo.AccountPingAn", "UnionBank", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountPingAn", "UnionBank");
            DropColumn("dbo.AccountPingAn", "AccountProp");
            DropColumn("dbo.AccountPingAn", "City");
            DropColumn("dbo.AccountPingAn", "Province");
            DropColumn("dbo.AccountPingAn", "AccountType");
            DropColumn("dbo.AccountPingAn", "BankName");
            DropColumn("dbo.AccountPingAn", "BankCode");
        }
    }
}
