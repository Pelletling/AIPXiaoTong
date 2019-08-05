namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl59 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderBooking", "EquipmentSNNo", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.OrderHousePayment", "EquipmentSNNo", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.OrderPaid", "EquipmentSNNo", c => c.String(nullable: false, maxLength: 32));
            DropColumn("dbo.OrderBooking", "EquipmentNumber");
            DropColumn("dbo.OrderHousePayment", "EquipmentNumber");
            DropColumn("dbo.OrderPaid", "EquipmentNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderPaid", "EquipmentNumber", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.OrderHousePayment", "EquipmentNumber", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.OrderBooking", "EquipmentNumber", c => c.String(nullable: false, maxLength: 32));
            DropColumn("dbo.OrderPaid", "EquipmentSNNo");
            DropColumn("dbo.OrderHousePayment", "EquipmentSNNo");
            DropColumn("dbo.OrderBooking", "EquipmentSNNo");
        }
    }
}
