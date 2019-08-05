namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUrl72 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderPaidRecharge",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    SerialNumber = c.String(maxLength: 32),
                    OrderPaidID = c.Long(),
                    Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TransNumber = c.String(maxLength: 32),
                    TransTime = c.DateTime(),
                    BankCardNumber = c.String(maxLength: 32),
                    Status = c.Int(nullable: false, defaultValue: 0),
                    CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    ModifyDatetime = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderPaid", t => t.OrderPaidID)
                .Index(t => t.OrderPaidID);

            DropColumn("dbo.OrderPaid", "SerialNumber");
            DropColumn("dbo.OrderPaid", "PaidTime");
            DropColumn("dbo.OrderPaid", "PaymentType");
            DropColumn("dbo.OrderPaid", "BankCardNumber");
        }

        public override void Down()
        {
            AddColumn("dbo.OrderPaid", "BankCardNumber", c => c.String(maxLength: 32));
            AddColumn("dbo.OrderPaid", "PaymentType", c => c.Int(nullable: false));
            AddColumn("dbo.OrderPaid", "PaidTime", c => c.DateTime());
            AddColumn("dbo.OrderPaid", "SerialNumber", c => c.String(maxLength: 32));
            DropForeignKey("dbo.OrderPaidRecharge", "OrderPaidID", "dbo.OrderPaid");
            DropIndex("dbo.OrderPaidRecharge", new[] { "OrderPaidID" });
            DropTable("dbo.OrderPaidRecharge");
        }
    }
}
