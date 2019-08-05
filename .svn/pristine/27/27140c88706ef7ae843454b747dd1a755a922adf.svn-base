namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl75 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderPaidWithdraw",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        SerialNumber = c.String(maxLength: 32),
                        OrderPaidID = c.Long(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ResponseCode = c.String(),
                        ResponseMessage = c.String(),
                        TransTime = c.DateTime(),
                        Status = c.Int(nullable: false,defaultValue:0),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderPaid", t => t.OrderPaidID)
                .Index(t => t.OrderPaidID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderPaidWithdraw", "OrderPaidID", "dbo.OrderPaid");
            DropIndex("dbo.OrderPaidWithdraw", new[] { "OrderPaidID" });
            DropTable("dbo.OrderPaidWithdraw");
        }
    }
}
