namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl48 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "CifAddr", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Member", "CifClientId", c => c.String(nullable: false, maxLength: 36));
            AddColumn("dbo.Member", "CifEnName", c => c.String(maxLength: 40));
            AddColumn("dbo.Member", "CifIdExpiredDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Member", "CifPostCode", c => c.String(nullable: false));
            AddColumn("dbo.Member", "ProvinceCode", c => c.String(nullable: false));
            AddColumn("dbo.Member", "CityCode", c => c.String(nullable: false));
            AddColumn("dbo.Member", "BankCardPhoneCode", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Member", "BankCardPhoneCode");
            DropColumn("dbo.Member", "CityCode");
            DropColumn("dbo.Member", "ProvinceCode");
            DropColumn("dbo.Member", "CifPostCode");
            DropColumn("dbo.Member", "CifIdExpiredDate");
            DropColumn("dbo.Member", "CifEnName");
            DropColumn("dbo.Member", "CifClientId");
            DropColumn("dbo.Member", "CifAddr");
        }
    }
}
