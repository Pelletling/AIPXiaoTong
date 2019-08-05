namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl98 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PingAnOrderPaid", "AutoLoginUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PingAnOrderPaid", "AutoLoginUrl");
        }
    }
}
