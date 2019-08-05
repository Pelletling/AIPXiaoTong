namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl102 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PingAnOrderPaid", "POSBaoSerialNumber", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PingAnOrderPaid", "POSBaoSerialNumber");
        }
    }
}
