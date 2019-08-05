namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DistrictManagement", "Remark", c => c.String(maxLength: 50));
            AlterColumn("dbo.ProjectManagement", "Description", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectManagement", "Description", c => c.String(maxLength: 32));
            AlterColumn("dbo.DistrictManagement", "Remark", c => c.String());
        }
    }
}
