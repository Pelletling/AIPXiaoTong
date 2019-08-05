namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertisingManagement",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ProjectManagementID = c.Long(nullable: false),
                        AdvertisingImg = c.String(nullable: false, maxLength: 128),
                        AdvertisingType = c.Int(nullable: false),
                        Remark = c.String(maxLength: 50),
                        PlayTime = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProjectManagement", t => t.ProjectManagementID, cascadeDelete: true)
                .Index(t => t.ProjectManagementID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertisingManagement", "ProjectManagementID", "dbo.ProjectManagement");
            DropIndex("dbo.AdvertisingManagement", new[] { "ProjectManagementID" });
            DropTable("dbo.AdvertisingManagement");
        }
    }
}
