namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl69 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "ProvinceCode", c => c.String(maxLength: 8));
            AlterColumn("dbo.Member", "CityCode", c => c.String(maxLength: 8));
            CreateIndex("dbo.Member", "ProvinceCode");
            CreateIndex("dbo.Member", "CityCode");
            AddForeignKey("dbo.Member", "CityCode", "dbo.AreaGuangDa", "Code");
            AddForeignKey("dbo.Member", "ProvinceCode", "dbo.AreaGuangDa", "Code");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Member", "ProvinceCode", "dbo.AreaGuangDa");
            DropForeignKey("dbo.Member", "CityCode", "dbo.AreaGuangDa");
            DropIndex("dbo.Member", new[] { "CityCode" });
            DropIndex("dbo.Member", new[] { "ProvinceCode" });
            AlterColumn("dbo.Member", "CityCode", c => c.String());
            AlterColumn("dbo.Member", "ProvinceCode", c => c.String());
        }
    }
}
