namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl17 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HouseTypeName",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MerchantID = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 32),
                        Remark = c.String(maxLength: 50),
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
            DropForeignKey("dbo.HouseTypeName", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.HouseTypeName", new[] { "MerchantID" });
            DropTable("dbo.HouseTypeName");
        }
    }
}
