namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl62 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "ProvinceCode", c => c.String(maxLength: 8));
            AlterColumn("dbo.Member", "CityCode", c => c.String(maxLength: 8));
            CreateIndex("dbo.Member", "ProvinceCode");
            CreateIndex("dbo.Member", "CityCode");
            AddForeignKey("dbo.Member", "CityCode", "dbo.Area", "Code");
            AddForeignKey("dbo.Member", "ProvinceCode", "dbo.Area", "Code");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Member", "ProvinceCode", "dbo.Area");
            DropForeignKey("dbo.Member", "CityCode", "dbo.Area");
            DropIndex("dbo.Member", new[] { "CityCode" });
            DropIndex("dbo.Member", new[] { "ProvinceCode" });
            AlterColumn("dbo.Member", "CityCode", c => c.String());
            AlterColumn("dbo.Member", "ProvinceCode", c => c.String());
        }
    }
}
