namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl105 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountPingAn", "CnName", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountPingAn", "CnName");
        }
    }
}
