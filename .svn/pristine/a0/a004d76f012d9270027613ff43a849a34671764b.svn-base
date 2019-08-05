namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl18 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HouseTypeShow",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MerchantID = c.Long(),
                        ProjectManagementID = c.Long(nullable: false),
                        HouseTypeNameID = c.Long(nullable: false),
                        HouseTypeArea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false, maxLength: 100),
                        HouseThumbnailImage = c.String(nullable: false, maxLength: 128),
                        HouseShowImage = c.String(maxLength: 128),
                        Content = c.String(),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HouseTypeName", t => t.HouseTypeNameID, cascadeDelete: true)
                .ForeignKey("dbo.Merchant", t => t.MerchantID)
                .ForeignKey("dbo.ProjectManagement", t => t.ProjectManagementID, cascadeDelete: true)
                .Index(t => t.MerchantID)
                .Index(t => t.ProjectManagementID)
                .Index(t => t.HouseTypeNameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HouseTypeShow", "ProjectManagementID", "dbo.ProjectManagement");
            DropForeignKey("dbo.HouseTypeShow", "MerchantID", "dbo.Merchant");
            DropForeignKey("dbo.HouseTypeShow", "HouseTypeNameID", "dbo.HouseTypeName");
            DropIndex("dbo.HouseTypeShow", new[] { "HouseTypeNameID" });
            DropIndex("dbo.HouseTypeShow", new[] { "ProjectManagementID" });
            DropIndex("dbo.HouseTypeShow", new[] { "MerchantID" });
            DropTable("dbo.HouseTypeShow");
        }
    }
}
