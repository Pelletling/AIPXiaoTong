namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl53 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "CifIdExpiredDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Member", "CifIdExpiredDate", c => c.String(nullable: false));
        }
    }
}
