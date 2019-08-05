namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl19 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HouseTypeShow", "HouseShowImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HouseTypeShow", "HouseShowImage", c => c.String(maxLength: 128));
        }
    }
}
