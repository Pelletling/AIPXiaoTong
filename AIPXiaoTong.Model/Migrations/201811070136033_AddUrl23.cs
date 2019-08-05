namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl23 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectManagement", "DistrictManagementID", "dbo.DistrictManagement");
            DropIndex("dbo.ProjectManagement", new[] { "DistrictManagementID" });
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 8),
                        Name = c.String(nullable: false, maxLength: 16),
                        ParentCode = c.String(maxLength: 8),
                        Level = c.Int(nullable: false),
                        ID = c.Long(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Area", t => t.ParentCode)
                .Index(t => t.Code, unique: true)
                .Index(t => t.ParentCode);
            
            AddColumn("dbo.ProjectManagement", "ProvinceCode", c => c.String(maxLength: 8));
            AddColumn("dbo.ProjectManagement", "CityCode", c => c.String(maxLength: 8));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Area", "ParentCode", "dbo.Area");
            DropIndex("dbo.Area", new[] { "ParentCode" });
            DropIndex("dbo.Area", new[] { "Code" });
            DropColumn("dbo.ProjectManagement", "CityCode");
            DropColumn("dbo.ProjectManagement", "ProvinceCode");
            DropTable("dbo.Area");
            CreateIndex("dbo.ProjectManagement", "DistrictManagementID");
            AddForeignKey("dbo.ProjectManagement", "DistrictManagementID", "dbo.DistrictManagement", "ID");
        }
    }
}
