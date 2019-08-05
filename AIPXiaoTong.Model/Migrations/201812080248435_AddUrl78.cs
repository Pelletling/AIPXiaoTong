namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl78 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "ResidueAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "ResidueAmount", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
