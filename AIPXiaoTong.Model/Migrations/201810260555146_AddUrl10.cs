namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectManagement",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MerchantID = c.Long(nullable: false),
                        ProjetName = c.String(nullable: false, maxLength: 32),
                        ProjectImage = c.String(maxLength: 128),
                        DistrictName = c.String(maxLength: 32),
                        ProjectAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ResidueAmount = c.Decimal(precision: 18, scale: 2),
                        Deadline = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 32),
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
            DropForeignKey("dbo.ProjectManagement", "MerchantID", "dbo.Merchant");
            DropIndex("dbo.ProjectManagement", new[] { "MerchantID" });
            DropTable("dbo.ProjectManagement");
        }
    }
}
