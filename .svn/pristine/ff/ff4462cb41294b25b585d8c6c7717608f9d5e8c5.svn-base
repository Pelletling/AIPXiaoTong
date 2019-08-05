namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectManagement", "AdvertisingImge", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectManagement", "AdvertisingImge");
        }
    }
}
