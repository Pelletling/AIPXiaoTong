namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl42 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderHousePayment", "MemberID", c => c.Long(nullable: false));
            CreateIndex("dbo.OrderHousePayment", "MemberID");
            AddForeignKey("dbo.OrderHousePayment", "MemberID", "dbo.Member", "ID", cascadeDelete: true);
            DropColumn("dbo.OrderHousePayment", "CustomerName");
            DropColumn("dbo.OrderHousePayment", "Mobile");
            DropColumn("dbo.OrderHousePayment", "IDNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderHousePayment", "IDNumber", c => c.String(maxLength: 32));
            AddColumn("dbo.OrderHousePayment", "Mobile", c => c.String(maxLength: 11));
            AddColumn("dbo.OrderHousePayment", "CustomerName", c => c.String(nullable: false, maxLength: 32));
            DropForeignKey("dbo.OrderHousePayment", "MemberID", "dbo.Member");
            DropIndex("dbo.OrderHousePayment", new[] { "MemberID" });
            DropColumn("dbo.OrderHousePayment", "MemberID");
        }
    }
}
