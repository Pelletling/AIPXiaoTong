namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl44 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderHousePayment", "SerialNumber", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderHousePayment", "SerialNumber", c => c.String(nullable: false, maxLength: 32));
        }
    }
}
