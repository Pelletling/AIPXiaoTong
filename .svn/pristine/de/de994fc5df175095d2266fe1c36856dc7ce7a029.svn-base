namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl51 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "IDImageFront", c => c.String(maxLength: 128));
            AddColumn("dbo.Member", "IDImageOpposite", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Member", "IDImageOpposite");
            DropColumn("dbo.Member", "IDImageFront");
        }
    }
}
