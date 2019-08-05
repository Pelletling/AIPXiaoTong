namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl81 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseTypeShow", "Reason", c => c.String(maxLength: 128));
            AlterColumn("dbo.Project", "Description", c => c.String(maxLength: 1024));
            AlterColumn("dbo.HouseTypeShow", "Content", c => c.String(maxLength: 1024));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HouseTypeShow", "Content", c => c.String(maxLength: 300));
            AlterColumn("dbo.Project", "Description", c => c.String(maxLength: 300));
            DropColumn("dbo.HouseTypeShow", "Reason");
        }
    }
}
