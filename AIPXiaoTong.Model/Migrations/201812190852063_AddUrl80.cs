namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl80 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "AdvertisingImge", c => c.String(nullable: false));
            AlterColumn("dbo.Project", "Description", c => c.String(maxLength: 300));
            AlterColumn("dbo.HouseTypeShow", "HouseShowImage", c => c.String(nullable: false));
            AlterColumn("dbo.HouseTypeShow", "Content", c => c.String(maxLength: 300));
            DropColumn("dbo.Project", "ProjectImage");
            DropColumn("dbo.HouseTypeShow", "Description");
            DropColumn("dbo.HouseTypeShow", "HouseThumbnailImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HouseTypeShow", "HouseThumbnailImage", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.HouseTypeShow", "Description", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Project", "ProjectImage", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.HouseTypeShow", "Content", c => c.String());
            AlterColumn("dbo.HouseTypeShow", "HouseShowImage", c => c.String());
            AlterColumn("dbo.Project", "Description", c => c.String(maxLength: 60));
            AlterColumn("dbo.Project", "AdvertisingImge", c => c.String());
        }
    }
}
