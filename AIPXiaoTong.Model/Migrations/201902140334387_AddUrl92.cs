namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl92 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PingAnOrderPaid",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        OrderPaidID = c.Long(nullable: false),
                        Channel = c.String(nullable: false),
                        BankOrderNo = c.String(maxLength: 20),
                        ClientNo = c.String(maxLength: 19),
                        BusinessName = c.String(nullable: false, maxLength: 60),
                        OrderValidDay = c.Int(nullable: false),
                        FreezeTimeLimit = c.Int(nullable: false),
                        FreezeProduct = c.Int(nullable: false),
                        AutoFreeze = c.String(nullable: false, maxLength: 2),
                        TransCode = c.String(nullable: false, maxLength: 16),
                        Status = c.Int(nullable: false,defaultValue:0),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderPaid", t => t.OrderPaidID, cascadeDelete: true)
                .Index(t => t.OrderPaidID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PingAnOrderPaid", "OrderPaidID", "dbo.OrderPaid");
            DropIndex("dbo.PingAnOrderPaid", new[] { "OrderPaidID" });
            DropTable("dbo.PingAnOrderPaid");
        }
    }
}
