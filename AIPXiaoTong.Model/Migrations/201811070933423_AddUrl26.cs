namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl26 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderHousePayment",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MerchantID = c.Long(),
                        OrderNumber = c.String(nullable: false, maxLength: 32),
                        ProjectManagementID = c.Long(),
                        EquipmentNumber = c.String(nullable: false, maxLength: 32),
                        Operator = c.String(nullable: false, maxLength: 32),
                        TransactionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SerialNumber = c.String(nullable: false, maxLength: 32),
                        CustomerName = c.String(nullable: false, maxLength: 32),
                        Mobile = c.String(maxLength: 11),
                        PaymentStatus = c.Int(nullable: false),
                        PaymentType = c.Int(nullable: false),
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
            DropForeignKey("dbo.OrderHousePayment", "ProjectManagementID", "dbo.ProjectManagement");
            DropForeignKey("dbo.OrderHousePayment", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.OrderHousePayment", new[] { "ProjectManagementID" });
            DropIndex("dbo.OrderHousePayment", new[] { "MerchantID" });
            DropTable("dbo.OrderHousePayment");
        }
    }
}
