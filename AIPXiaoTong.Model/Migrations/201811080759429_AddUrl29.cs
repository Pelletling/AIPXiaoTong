namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl29 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DistrictManagement", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.DistrictManagement", new[] { "MerchantID" });
            DropTable("dbo.DistrictManagement");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DistrictManagement",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MerchantID = c.Long(nullable: false),
                        DistrictName = c.String(nullable: false, maxLength: 32),
                        Remark = c.String(maxLength: 50),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.DistrictManagement", "MerchantID");
            AddForeignKey("dbo.DistrictManagement", "MerchantID", "dbo.Merchant", "ID", cascadeDelete: true);
        }
    }
}
