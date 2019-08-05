namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl87 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountGuangDa", "GuangDaAreaID", c => c.Long());
            CreateIndex("dbo.AccountGuangDa", "GuangDaAreaID");
            AddForeignKey("dbo.AccountGuangDa", "GuangDaAreaID", "dbo.GuangDaArea", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountGuangDa", "GuangDaAreaID", "dbo.GuangDaArea");
            DropIndex("dbo.AccountGuangDa", new[] { "GuangDaAreaID" });
            DropColumn("dbo.AccountGuangDa", "GuangDaAreaID");
        }
    }
}
