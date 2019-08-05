namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl24 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProjectManagement", "DistrictManagementID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectManagement", "DistrictManagementID", c => c.Long());
        }
    }
}
