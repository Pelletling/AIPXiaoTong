namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl109 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "StartTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "StartTime");
        }
    }
}
