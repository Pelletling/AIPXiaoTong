namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl88 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountGuangDa", "CoPatrnerJnlNo", c => c.String(maxLength: 32));
            AddColumn("dbo.AccountGuangDa", "BookDate", c => c.DateTime());
            AddColumn("dbo.AccountGuangDa", "EAcNo", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountGuangDa", "EAcNo");
            DropColumn("dbo.AccountGuangDa", "BookDate");
            DropColumn("dbo.AccountGuangDa", "CoPatrnerJnlNo");
        }
    }
}
