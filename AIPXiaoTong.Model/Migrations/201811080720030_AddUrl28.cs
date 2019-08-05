namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl28 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HouseTypeName", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.HouseTypeName", new[] { "MerchantID" });
            DropTable("dbo.HouseTypeName");
        }
        
        public override void Down()
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
                        CreateDatetime = c.DateTime(nullable: false),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.HouseTypeName", "MerchantID");
            AddForeignKey("dbo.HouseTypeName", "MerchantID", "dbo.Merchant", "ID", cascadeDelete: true);
        }
    }
}
