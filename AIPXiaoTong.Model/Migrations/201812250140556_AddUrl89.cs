namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl89 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.GuangDaArea", new[] { "Code" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.GuangDaArea", "Code", unique: true);
        }
    }
}
