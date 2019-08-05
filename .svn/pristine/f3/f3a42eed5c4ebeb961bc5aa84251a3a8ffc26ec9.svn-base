namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl27 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderPaid",
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
                        IDNumber = c.String(maxLength: 32),
                        BankCardNumber = c.String(maxLength: 32),
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
            
            AddColumn("dbo.OrderHousePayment", "IDNumber", c => c.String(maxLength: 32));
            AddColumn("dbo.OrderHousePayment", "BankCardNumber", c => c.String(maxLength: 32));
            AddColumn("dbo.OrderHousePayment", "Remark", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderPaid", "ProjectManagementID", "dbo.ProjectManagement");
            DropForeignKey("dbo.OrderPaid", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.OrderPaid", new[] { "ProjectManagementID" });
            DropIndex("dbo.OrderPaid", new[] { "MerchantID" });
            DropColumn("dbo.OrderHousePayment", "Remark");
            DropColumn("dbo.OrderHousePayment", "BankCardNumber");
            DropColumn("dbo.OrderHousePayment", "IDNumber");
            DropTable("dbo.OrderPaid");
        }
    }
}
