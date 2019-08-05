namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUrl91 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "ReceiveAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValue: 0));
            DropColumn("dbo.Project", "ResidueAmount");
        }

        public override void Down()
        {
            AddColumn("dbo.Project", "ResidueAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Project", "ReceiveAmount");
        }
    }
}
