namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl82 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderPaid", "PayAction", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderPaid", "PayAction");
        }
    }
}
