namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl103 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountPingAn", "outCardNo", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountPingAn", "outCardNo");
        }
    }
}
