namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl116 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TLTPreferences", "TLTSecurityCer", c => c.String(nullable: false));
            AddColumn("dbo.TLTPreferences", "TLTPrivateKeyCer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TLTPreferences", "TLTPrivateKeyCer");
            DropColumn("dbo.TLTPreferences", "TLTSecurityCer");
        }
    }
}
