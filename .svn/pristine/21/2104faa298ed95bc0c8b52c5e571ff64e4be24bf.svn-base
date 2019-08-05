namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdvertisingManagement", "Reason", c => c.String(maxLength: 128));
            AddColumn("dbo.ProjectManagement", "Reason", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectManagement", "Reason");
            DropColumn("dbo.AdvertisingManagement", "Reason");
        }
    }
}
