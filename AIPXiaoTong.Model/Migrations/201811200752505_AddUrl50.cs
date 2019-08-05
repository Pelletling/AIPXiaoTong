namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl50 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "CifAddr", c => c.String(maxLength: 30));
            AlterColumn("dbo.Member", "CifClientId", c => c.String(maxLength: 36));
            AlterColumn("dbo.Member", "CifPostCode", c => c.String());
            AlterColumn("dbo.Member", "ProvinceCode", c => c.String());
            AlterColumn("dbo.Member", "CityCode", c => c.String());
            AlterColumn("dbo.Member", "BankCardPhoneCode", c => c.String(maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Member", "BankCardPhoneCode", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Member", "CityCode", c => c.String(nullable: false));
            AlterColumn("dbo.Member", "ProvinceCode", c => c.String(nullable: false));
            AlterColumn("dbo.Member", "CifPostCode", c => c.String(nullable: false));
            AlterColumn("dbo.Member", "CifClientId", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("dbo.Member", "CifAddr", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
