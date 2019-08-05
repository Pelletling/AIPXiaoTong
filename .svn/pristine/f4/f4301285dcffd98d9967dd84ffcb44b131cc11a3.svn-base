namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl117 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Equipment", "EquipmentSNNo", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Equipment", new[] { "EquipmentSNNo" });
        }
    }
}
