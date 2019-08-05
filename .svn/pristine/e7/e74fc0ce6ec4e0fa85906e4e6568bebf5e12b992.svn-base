namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberManagement",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 16),
                        ProjectManagementID = c.Long(nullable: false),
                        IDNumber = c.String(maxLength: 32),
                        Mobile = c.String(nullable: false, maxLength: 16),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProjectManagement", t => t.ProjectManagementID, cascadeDelete: true)
                .Index(t => t.ProjectManagementID)
                .Index(t => t.Mobile, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberManagement", "ProjectManagementID", "dbo.ProjectManagement");
            DropIndex("dbo.MemberManagement", new[] { "Mobile" });
            DropIndex("dbo.MemberManagement", new[] { "ProjectManagementID" });
            DropTable("dbo.MemberManagement");
        }
    }
}
