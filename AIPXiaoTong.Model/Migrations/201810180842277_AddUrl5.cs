namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUrl5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "IsAdmin", c => c.Int(nullable: false, defaultValue: 0));
        }

        public override void Down()
        {
            DropColumn("dbo.Employee", "IsAdmin");
        }
    }
}
