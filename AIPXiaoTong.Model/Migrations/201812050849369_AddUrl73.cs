namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUrl73 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderPaidFreeze",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    SerialNumber = c.String(maxLength: 32),
                    OrderPaidID = c.Long(),
                    Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    UnFreezeDate = c.DateTime(nullable: false),
                    ResponseCode = c.String(),
                    ResponseMessage = c.String(),
                    Status = c.Int(nullable: false, defaultValue: 0),
                    CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    ModifyDatetime = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderPaid", t => t.OrderPaidID)
                .Index(t => t.OrderPaidID);

            AddColumn("dbo.OrderPaidRecharge", "ResponseCode", c => c.String());
            AddColumn("dbo.OrderPaidRecharge", "ResponseMessage", c => c.String());
        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderPaidFreeze", "OrderPaidID", "dbo.OrderPaid");
            DropIndex("dbo.OrderPaidFreeze", new[] { "OrderPaidID" });
            DropColumn("dbo.OrderPaidRecharge", "ResponseMessage");
            DropColumn("dbo.OrderPaidRecharge", "ResponseCode");
            DropTable("dbo.OrderPaidFreeze");
        }
    }
}
