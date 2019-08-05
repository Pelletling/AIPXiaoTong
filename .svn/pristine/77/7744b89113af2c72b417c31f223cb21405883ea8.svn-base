namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl32 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectManagement", "AdvertisingImge", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectManagement", "AdvertisingImge", c => c.String(maxLength: 128));
        }
    }
}
