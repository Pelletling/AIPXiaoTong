namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Preferences",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MerchantID = c.Long(nullable: false),
                        MerchantInfo = c.String(nullable: false, maxLength: 32),
                        MerchantUrl = c.String(),
                        SecretKey = c.String(maxLength: 64),
                        APPID = c.String(nullable: false, maxLength: 32),
                        POSBaoMerchant = c.String(nullable: false, maxLength: 32),
                        POSBaoKey = c.String(nullable: false, maxLength: 32),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Merchant", t => t.MerchantID, cascadeDelete: true)
                .Index(t => t.MerchantID)
                .Index(t => t.MerchantInfo, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Preferences", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.Preferences", new[] { "MerchantInfo" });
            DropIndex("dbo.Preferences", new[] { "MerchantID" });
            DropTable("dbo.Preferences");
        }
    }
}
