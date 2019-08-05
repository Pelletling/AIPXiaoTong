namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl25 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderBooking",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MerchantID = c.Long(),
                        OrderNumber = c.String(nullable: false, maxLength: 32),
                        ProjectManagementID = c.Long(),
                        EquipmentNumber = c.String(nullable: false, maxLength: 32),
                        Operator = c.String(nullable: false, maxLength: 32),
                        CustomerName = c.String(nullable: false, maxLength: 32),
                        Mobile = c.String(maxLength: 11),
                        IDNumber = c.String(maxLength: 32),
                        OrderTime = c.DateTime(nullable: false),
                        Remark = c.String(maxLength: 50),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Merchant", t => t.MerchantID)
                .ForeignKey("dbo.ProjectManagement", t => t.ProjectManagementID)
                .Index(t => t.MerchantID)
                .Index(t => t.ProjectManagementID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderBooking", "ProjectManagementID", "dbo.ProjectManagement");
            DropForeignKey("dbo.OrderBooking", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.OrderBooking", new[] { "ProjectManagementID" });
            DropIndex("dbo.OrderBooking", new[] { "MerchantID" });
            DropTable("dbo.OrderBooking");
        }
    }
}
