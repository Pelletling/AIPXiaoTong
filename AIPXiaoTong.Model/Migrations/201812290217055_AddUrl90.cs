namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl90 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "IsMore", c => c.Int(nullable: false));
            AddColumn("dbo.Employee", "AuthDepartmentIDs", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "AuthDepartmentIDs");
            DropColumn("dbo.Employee", "IsMore");
        }
    }
}
