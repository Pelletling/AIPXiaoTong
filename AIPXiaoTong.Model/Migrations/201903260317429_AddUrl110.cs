namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl110 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PingAnOrderPaid", "AutoLoginUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PingAnOrderPaid", "AutoLoginUrl", c => c.String());
        }
    }
}
