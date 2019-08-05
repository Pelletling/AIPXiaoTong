namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl68 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Member", "CityCode", "dbo.Area");
            DropForeignKey("dbo.Member", "ProvinceCode", "dbo.Area");
            DropIndex("dbo.Member", new[] { "ProvinceCode" });
            DropIndex("dbo.Member", new[] { "CityCode" });
            AlterColumn("dbo.Member", "ProvinceCode", c => c.String());
            AlterColumn("dbo.Member", "CityCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Member", "CityCode", c => c.String(maxLength: 8));
            AlterColumn("dbo.Member", "ProvinceCode", c => c.String(maxLength: 8));
            CreateIndex("dbo.Member", "CityCode");
            CreateIndex("dbo.Member", "ProvinceCode");
            AddForeignKey("dbo.Member", "ProvinceCode", "dbo.Area", "Code");
            AddForeignKey("dbo.Member", "CityCode", "dbo.Area", "Code");
        }
    }
}
