namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl39 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MemberManagement", "MerchantID", "dbo.Merchant");
            DropForeignKey("dbo.MemberManagement", "ProjectManagementID", "dbo.ProjectManagement");
            DropIndex("dbo.MemberManagement", new[] { "MerchantID" });
            DropIndex("dbo.MemberManagement", new[] { "ProjectManagementID" });
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 16),
                        IDNumber = c.String(maxLength: 32),
                        Mobile = c.String(nullable: false, maxLength: 16),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.MemberManagement");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MemberManagement",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MerchantID = c.Long(),
                        Name = c.String(nullable: false, maxLength: 16),
                        ProjectManagementID = c.Long(nullable: false),
                        IDNumber = c.String(maxLength: 32),
                        Mobile = c.String(nullable: false, maxLength: 16),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Member");
            CreateIndex("dbo.MemberManagement", "ProjectManagementID");
            CreateIndex("dbo.MemberManagement", "MerchantID");
            AddForeignKey("dbo.MemberManagement", "ProjectManagementID", "dbo.ProjectManagement", "ID", cascadeDelete: true);
            AddForeignKey("dbo.MemberManagement", "MerchantID", "dbo.Merchant", "ID");
        }
    }
}
