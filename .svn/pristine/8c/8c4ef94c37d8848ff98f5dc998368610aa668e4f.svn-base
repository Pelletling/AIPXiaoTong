namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl45 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderPaid", "OrderNumber", c => c.String(maxLength: 32));
            AlterColumn("dbo.OrderPaid", "SerialNumber", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderPaid", "SerialNumber", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.OrderPaid", "OrderNumber", c => c.String(nullable: false, maxLength: 32));
        }
    }
}
