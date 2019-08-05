namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl38 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MemberManagement", new[] { "Mobile" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.MemberManagement", "Mobile", unique: true);
        }
    }
}
