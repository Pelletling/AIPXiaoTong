namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl60 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Equipment", "EquipmentNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipment", "EquipmentNo", c => c.String(nullable: false, maxLength: 32));
        }
    }
}
