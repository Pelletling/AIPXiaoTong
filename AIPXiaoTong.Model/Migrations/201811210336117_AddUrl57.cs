namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUrl57 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "IsCreateAccount", c => c.Int(nullable: false, defaultValue: 0));
        }

        public override void Down()
        {
            DropColumn("dbo.Member", "IsCreateAccount");
        }
    }
}
