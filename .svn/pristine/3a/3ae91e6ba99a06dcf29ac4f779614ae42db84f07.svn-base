namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUrl77 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberBalanceHistory",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    MemberID = c.Long(nullable: false),
                    ChangeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Type = c.Int(nullable: false, defaultValue: 0),
                    Remark = c.String(maxLength: 32),
                    Status = c.Int(nullable: false, defaultValue: 0),
                    CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    ModifyDatetime = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Member", t => t.MemberID)
                .Index(t => t.MemberID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.MemberBalanceHistory", "MemberID", "dbo.Member");
            DropIndex("dbo.MemberBalanceHistory", new[] { "MemberID" });
            DropTable("dbo.MemberBalanceHistory");
        }
    }
}
