namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl100 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PingAnOrderPaid", "FreezeSuccessTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PingAnOrderPaid", "FreezeSuccessTime");
        }
    }
}
