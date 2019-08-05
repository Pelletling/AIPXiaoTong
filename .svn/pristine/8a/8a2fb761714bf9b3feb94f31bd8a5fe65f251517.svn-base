namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUrl4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    MerchantID = c.Long(nullable: false),
                    Code = c.String(nullable: false, maxLength: 16),
                    Name = c.String(nullable: false, maxLength: 64),
                    Email = c.String(maxLength: 64),
                    Mobile = c.String(maxLength: 11),
                    Password = c.String(nullable: false, maxLength: 32),
                    Status = c.Int(nullable: false, defaultValue: 0),
                    CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    ModifyDatetime = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Merchant", t => t.MerchantID)
                .Index(t => t.MerchantID);

            CreateTable(
                "dbo.Merchant",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    Code = c.String(nullable: false, maxLength: 16),
                    Name = c.String(nullable: false, maxLength: 64),
                    Contact = c.String(maxLength: 16),
                    Mobile = c.String(maxLength: 16),
                    Status = c.Int(nullable: false, defaultValue: 0),
                    CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    ModifyDatetime = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Employee", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.Employee", new[] { "MerchantID" });
            DropTable("dbo.Merchant");
            DropTable("dbo.Employee");
        }
    }
}
