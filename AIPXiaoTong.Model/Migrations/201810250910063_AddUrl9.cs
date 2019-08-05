namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DistrictManagement",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MerchantID = c.Long(nullable: false),
                        DistrictName = c.String(nullable: false, maxLength: 32),
                        Remark = c.String(),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Merchant", t => t.MerchantID, cascadeDelete: true)
                .Index(t => t.MerchantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DistrictManagement", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.DistrictManagement", new[] { "MerchantID" });
            DropTable("dbo.DistrictManagement");
        }
    }
}
