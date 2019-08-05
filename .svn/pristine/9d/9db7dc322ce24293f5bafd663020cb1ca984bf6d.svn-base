namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl40 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdvertisingManagement", "ProjectManagementID", "dbo.ProjectManagement");
            DropIndex("dbo.AdvertisingManagement", new[] { "ProjectManagementID" });
            DropTable("dbo.AdvertisingManagement");
        }
        
        public override void Down()
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
                        Reason = c.String(maxLength: 128),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.AdvertisingManagement", "ProjectManagementID");
            AddForeignKey("dbo.AdvertisingManagement", "ProjectManagementID", "dbo.ProjectManagement", "ID", cascadeDelete: true);
        }
    }
}
