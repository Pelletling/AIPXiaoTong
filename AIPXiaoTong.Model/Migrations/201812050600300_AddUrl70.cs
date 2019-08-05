namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl70 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderPaid", "PaidTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.OrderPaid", "PaymentStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderPaid", "PaymentStatus", c => c.Int(nullable: false));
            DropColumn("dbo.OrderPaid", "PaidTime");
        }
    }
}
