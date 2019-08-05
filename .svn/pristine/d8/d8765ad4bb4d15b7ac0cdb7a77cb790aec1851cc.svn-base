namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUrl115 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TLTPreferences",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    MerchantID = c.Long(nullable: false),
                    TltMerchantId = c.String(nullable: false, maxLength: 32),
                    TltUserName = c.String(nullable: false, maxLength: 32),
                    TltUserPassword = c.String(nullable: false, maxLength: 32),
                    TltPrivateKeyPassword = c.String(nullable: false, maxLength: 32),
                    Status = c.Int(nullable: false, defaultValue: 0),
                    CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    ModifyDatetime = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Merchant", t => t.MerchantID, cascadeDelete: true)
                .Index(t => t.MerchantID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.TLTPreferences", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.TLTPreferences", new[] { "MerchantID" });
            DropTable("dbo.TLTPreferences");
        }
    }
}
