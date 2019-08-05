namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl49 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "CifIdExpiredDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Member", "CifIdExpiredDate", c => c.DateTime(nullable: false));
        }
    }
}
