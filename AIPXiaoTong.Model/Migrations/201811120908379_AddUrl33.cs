namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl33 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MerchantID = c.Long(),
                        EquipmentNo = c.String(nullable: false, maxLength: 32),
                        EquipmentSNNo = c.String(nullable: false, maxLength: 32),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Merchant", t => t.MerchantID)
                .Index(t => t.MerchantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipment", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.Equipment", new[] { "MerchantID" });
            DropTable("dbo.Equipment");
        }
    }
}
