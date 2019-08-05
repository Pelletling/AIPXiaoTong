namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl54 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderBooking", "OrderName", c => c.String(maxLength: 32));
            AddColumn("dbo.OrderBooking", "OrderMobile", c => c.String(maxLength: 11));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderBooking", "OrderMobile");
            DropColumn("dbo.OrderBooking", "OrderName");
        }
    }
}
