namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl58 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderBooking", "MemberID", "dbo.Member");
            DropIndex("dbo.OrderBooking", new[] { "MemberID" });
            AlterColumn("dbo.OrderBooking", "MemberID", c => c.Long());
            CreateIndex("dbo.OrderBooking", "MemberID");
            AddForeignKey("dbo.OrderBooking", "MemberID", "dbo.Member", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderBooking", "MemberID", "dbo.Member");
            DropIndex("dbo.OrderBooking", new[] { "MemberID" });
            AlterColumn("dbo.OrderBooking", "MemberID", c => c.Long(nullable: false));
            CreateIndex("dbo.OrderBooking", "MemberID");
            AddForeignKey("dbo.OrderBooking", "MemberID", "dbo.Member", "ID", cascadeDelete: true);
        }
    }
}
