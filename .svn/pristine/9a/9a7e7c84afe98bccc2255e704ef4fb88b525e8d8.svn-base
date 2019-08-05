namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderBooking", "MemberID", c => c.Long(nullable: false));
            CreateIndex("dbo.OrderBooking", "MemberID");
            AddForeignKey("dbo.OrderBooking", "MemberID", "dbo.Member", "ID", cascadeDelete: true);
            DropColumn("dbo.OrderBooking", "CustomerName");
            DropColumn("dbo.OrderBooking", "Mobile");
            DropColumn("dbo.OrderBooking", "IDNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderBooking", "IDNumber", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.OrderBooking", "Mobile", c => c.String(nullable: false, maxLength: 11));
            AddColumn("dbo.OrderBooking", "CustomerName", c => c.String(nullable: false, maxLength: 32));
            DropForeignKey("dbo.OrderBooking", "MemberID", "dbo.Member");
            DropIndex("dbo.OrderBooking", new[] { "MemberID" });
            DropColumn("dbo.OrderBooking", "MemberID");
        }
    }
}
