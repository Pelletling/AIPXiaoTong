namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl71 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderPaid", "PaidTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderPaid", "PaidTime", c => c.DateTime(nullable: false));
        }
    }
}
