namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl85 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Member", "CityCode", "dbo.AreaGuangDa");
            DropForeignKey("dbo.Member", "ProvinceCode", "dbo.AreaGuangDa");
            DropIndex("dbo.Member", new[] { "ProvinceCode" });
            DropIndex("dbo.Member", new[] { "CityCode" });
            CreateTable(
                "dbo.AccountGuangDa",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        MemberID = c.Long(nullable: false),
                        Mobile = c.String(maxLength: 11),
                        Address = c.String(maxLength: 128),
                        EnName = c.String(maxLength: 32),
                        IdExpiredDate = c.DateTime(),
                        PostCode = c.String(maxLength: 6),
                        ProvinceCode = c.String(maxLength: 8),
                        CityCode = c.String(maxLength: 8),
                        IDImageFront = c.String(maxLength: 128),
                        IDImageOpposite = c.String(maxLength: 128),
                        IsCreateAccount = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FreezeBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false,defaultValue:0),
                        CreateDatetime = c.DateTime(nullable: false,defaultValueSql:"getdate()"),
                        ModifyDatetime = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AreaGuangDa", t => t.CityCode)
                .ForeignKey("dbo.Member", t => t.MemberID)
                .ForeignKey("dbo.AreaGuangDa", t => t.ProvinceCode)
                .Index(t => t.MemberID, unique: true)
                .Index(t => t.ProvinceCode)
                .Index(t => t.CityCode);
            
            AddColumn("dbo.Merchant", "AccountBank", c => c.Int(nullable: false));
            AddColumn("dbo.MemberBalanceHistory", "AccountBank", c => c.Int(nullable: false));
            DropColumn("dbo.Member", "Address");
            DropColumn("dbo.Member", "EnName");
            DropColumn("dbo.Member", "IdExpiredDate");
            DropColumn("dbo.Member", "PostCode");
            DropColumn("dbo.Member", "ProvinceCode");
            DropColumn("dbo.Member", "CityCode");
            DropColumn("dbo.Member", "IDImageFront");
            DropColumn("dbo.Member", "IDImageOpposite");
            DropColumn("dbo.Member", "IsCreateAccount");
            DropColumn("dbo.Member", "Balance");
            DropColumn("dbo.Member", "FreezeBalance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Member", "FreezeBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Member", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Member", "IsCreateAccount", c => c.Int(nullable: false));
            AddColumn("dbo.Member", "IDImageOpposite", c => c.String(maxLength: 128));
            AddColumn("dbo.Member", "IDImageFront", c => c.String(maxLength: 128));
            AddColumn("dbo.Member", "CityCode", c => c.String(maxLength: 8));
            AddColumn("dbo.Member", "ProvinceCode", c => c.String(maxLength: 8));
            AddColumn("dbo.Member", "PostCode", c => c.String(maxLength: 6));
            AddColumn("dbo.Member", "IdExpiredDate", c => c.DateTime());
            AddColumn("dbo.Member", "EnName", c => c.String(maxLength: 32));
            AddColumn("dbo.Member", "Address", c => c.String(maxLength: 128));
            DropForeignKey("dbo.AccountGuangDa", "ProvinceCode", "dbo.AreaGuangDa");
            DropForeignKey("dbo.AccountGuangDa", "MemberID", "dbo.Member");
            DropForeignKey("dbo.AccountGuangDa", "CityCode", "dbo.AreaGuangDa");
            DropIndex("dbo.AccountGuangDa", new[] { "CityCode" });
            DropIndex("dbo.AccountGuangDa", new[] { "ProvinceCode" });
            DropIndex("dbo.AccountGuangDa", new[] { "MemberID" });
            DropColumn("dbo.MemberBalanceHistory", "AccountBank");
            DropColumn("dbo.Merchant", "AccountBank");
            DropTable("dbo.AccountGuangDa");
            CreateIndex("dbo.Member", "CityCode");
            CreateIndex("dbo.Member", "ProvinceCode");
            AddForeignKey("dbo.Member", "ProvinceCode", "dbo.AreaGuangDa", "Code");
            AddForeignKey("dbo.Member", "CityCode", "dbo.AreaGuangDa", "Code");
        }
    }
}
