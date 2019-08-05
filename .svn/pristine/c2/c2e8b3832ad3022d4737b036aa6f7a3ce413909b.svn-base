namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Mobile", c => c.String(maxLength: 11));
            AddColumn("dbo.Users", "IsMore", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "IsMort");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsMort", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "IsMore");
            DropColumn("dbo.Users", "Mobile");
        }
    }
}
