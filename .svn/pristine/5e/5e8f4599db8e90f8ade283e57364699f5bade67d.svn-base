namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PingAnOrderPaidRecharge", "AccountName", c => c.String(maxLength: 32));
            AddColumn("dbo.PingAnOrderPaidRecharge", "IDNumber", c => c.String(maxLength: 18));
            AddColumn("dbo.PingAnOrderPaidRecharge", "BankCode", c => c.String(maxLength: 32));
            AddColumn("dbo.PingAnOrderPaidRecharge", "BankName", c => c.String(maxLength: 32));
            AddColumn("dbo.PingAnOrderPaidRecharge", "AccountType", c => c.String(maxLength: 32));
            AddColumn("dbo.PingAnOrderPaidRecharge", "Province", c => c.String(maxLength: 32));
            AddColumn("dbo.PingAnOrderPaidRecharge", "City", c => c.String(maxLength: 32));
            AddColumn("dbo.PingAnOrderPaidRecharge", "AccountProp", c => c.String(maxLength: 32));
            AddColumn("dbo.PingAnOrderPaidRecharge", "UnionBank", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PingAnOrderPaidRecharge", "UnionBank");
            DropColumn("dbo.PingAnOrderPaidRecharge", "AccountProp");
            DropColumn("dbo.PingAnOrderPaidRecharge", "City");
            DropColumn("dbo.PingAnOrderPaidRecharge", "Province");
            DropColumn("dbo.PingAnOrderPaidRecharge", "AccountType");
            DropColumn("dbo.PingAnOrderPaidRecharge", "BankName");
            DropColumn("dbo.PingAnOrderPaidRecharge", "BankCode");
            DropColumn("dbo.PingAnOrderPaidRecharge", "IDNumber");
            DropColumn("dbo.PingAnOrderPaidRecharge", "AccountName");
        }
    }
}
