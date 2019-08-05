namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl106 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "GuaranteeAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Project", "GuaranteeMonth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "GuaranteeMonth");
            DropColumn("dbo.Project", "GuaranteeAmount");
        }
    }
}
