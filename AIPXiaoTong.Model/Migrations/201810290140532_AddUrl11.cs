namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectManagement", "ResidueAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectManagement", "ResidueAmount", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
