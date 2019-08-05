namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl86 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountGuangDa", "Occupation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountGuangDa", "Occupation");
        }
    }
}
