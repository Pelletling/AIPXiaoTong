namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl37 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectManagement", "ProvinceCode", c => c.String(maxLength: 8));
            AlterColumn("dbo.ProjectManagement", "CityCode", c => c.String(maxLength: 8));
            CreateIndex("dbo.ProjectManagement", "ProvinceCode");
            CreateIndex("dbo.ProjectManagement", "CityCode");
            AddForeignKey("dbo.ProjectManagement", "CityCode", "dbo.Area", "Code");
            AddForeignKey("dbo.ProjectManagement", "ProvinceCode", "dbo.Area", "Code");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectManagement", "ProvinceCode", "dbo.Area");
            DropForeignKey("dbo.ProjectManagement", "CityCode", "dbo.Area");
            DropIndex("dbo.ProjectManagement", new[] { "CityCode" });
            DropIndex("dbo.ProjectManagement", new[] { "ProvinceCode" });
            AlterColumn("dbo.ProjectManagement", "CityCode", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.ProjectManagement", "ProvinceCode", c => c.String(nullable: false, maxLength: 8));
        }
    }
}
