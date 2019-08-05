namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl43 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderPaid", "MemberID", c => c.Long(nullable: false));
            CreateIndex("dbo.OrderPaid", "MemberID");
            AddForeignKey("dbo.OrderPaid", "MemberID", "dbo.Member", "ID", cascadeDelete: true);
            DropColumn("dbo.OrderPaid", "CustomerName");
            DropColumn("dbo.OrderPaid", "Mobile");
            DropColumn("dbo.OrderPaid", "IDNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderPaid", "IDNumber", c => c.String(maxLength: 32));
            AddColumn("dbo.OrderPaid", "Mobile", c => c.String(maxLength: 11));
            AddColumn("dbo.OrderPaid", "CustomerName", c => c.String(nullable: false, maxLength: 32));
            DropForeignKey("dbo.OrderPaid", "MemberID", "dbo.Member");
            DropIndex("dbo.OrderPaid", new[] { "MemberID" });
            DropColumn("dbo.OrderPaid", "MemberID");
        }
    }
}
