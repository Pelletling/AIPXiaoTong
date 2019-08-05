namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl35 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderHousePayment", "EmployeeID", c => c.Long());
            AddColumn("dbo.OrderPaid", "EmployeeID", c => c.Long());
            CreateIndex("dbo.OrderHousePayment", "EmployeeID");
            CreateIndex("dbo.OrderPaid", "EmployeeID");
            AddForeignKey("dbo.OrderHousePayment", "EmployeeID", "dbo.Employee", "ID");
            AddForeignKey("dbo.OrderPaid", "EmployeeID", "dbo.Employee", "ID");
            DropColumn("dbo.OrderHousePayment", "Operator");
            DropColumn("dbo.OrderPaid", "Operator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderPaid", "Operator", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.OrderHousePayment", "Operator", c => c.String(nullable: false, maxLength: 32));
            DropForeignKey("dbo.OrderPaid", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.OrderHousePayment", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.OrderPaid", new[] { "EmployeeID" });
            DropIndex("dbo.OrderHousePayment", new[] { "EmployeeID" });
            DropColumn("dbo.OrderPaid", "EmployeeID");
            DropColumn("dbo.OrderHousePayment", "EmployeeID");
        }
    }
}
