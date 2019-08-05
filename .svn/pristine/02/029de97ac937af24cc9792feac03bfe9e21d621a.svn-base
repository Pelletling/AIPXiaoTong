namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderBooking", "EmployeeID", c => c.Long());
            CreateIndex("dbo.OrderBooking", "EmployeeID");
            AddForeignKey("dbo.OrderBooking", "EmployeeID", "dbo.Employee", "ID");
            DropColumn("dbo.OrderBooking", "Operator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderBooking", "Operator", c => c.String(nullable: false, maxLength: 32));
            DropForeignKey("dbo.OrderBooking", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.OrderBooking", new[] { "EmployeeID" });
            DropColumn("dbo.OrderBooking", "EmployeeID");
        }
    }
}
