namespace AIPXiaoTong.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUrl56 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bank",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    Code = c.String(nullable: false, maxLength: 16),
                    Name = c.String(nullable: false, maxLength: 32),
                    CodeGuangDa = c.String(),
                    Status = c.Int(nullable: false, defaultValue: 0),
                    CreateDatetime = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    ModifyDatetime = c.DateTime(),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);

            AddColumn("dbo.BankCard", "Mobile", c => c.String(maxLength: 11));
            AddColumn("dbo.BankCard", "BankID", c => c.Long(nullable: false));
            AddColumn("dbo.Member", "Address", c => c.String(maxLength: 128));
            AddColumn("dbo.Member", "ClientId", c => c.String(nullable: false, maxLength: 36));
            AddColumn("dbo.Member", "EnName", c => c.String(maxLength: 32));
            AddColumn("dbo.Member", "IdExpiredDate", c => c.DateTime());
            AddColumn("dbo.Member", "PostCode", c => c.String(maxLength: 6));
            AlterColumn("dbo.BankCard", "SubBranchName", c => c.String(maxLength: 32));
            AlterColumn("dbo.Member", "IDNumber", c => c.String(maxLength: 18));
            AlterColumn("dbo.Member", "Mobile", c => c.String(maxLength: 11));
            CreateIndex("dbo.BankCard", "BankCardNumber", unique: true);
            CreateIndex("dbo.BankCard", "BankID");
            CreateIndex("dbo.Member", "IDNumber", unique: true);
            AddForeignKey("dbo.BankCard", "BankID", "dbo.Bank", "ID", cascadeDelete: true);
            DropColumn("dbo.BankCard", "BankName");
            DropColumn("dbo.BankCard", "Verified");
            DropColumn("dbo.Member", "MerchantID");
            DropColumn("dbo.Member", "CifAddr");
            DropColumn("dbo.Member", "CifClientId");
            DropColumn("dbo.Member", "CifEnName");
            DropColumn("dbo.Member", "CifIdExpiredDate");
            DropColumn("dbo.Member", "CifPostCode");
            DropColumn("dbo.Member", "BankCardPhoneCode");
        }

        public override void Down()
        {
            AddColumn("dbo.Member", "BankCardPhoneCode", c => c.String(maxLength: 11));
            AddColumn("dbo.Member", "CifPostCode", c => c.String());
            AddColumn("dbo.Member", "CifIdExpiredDate", c => c.String());
            AddColumn("dbo.Member", "CifEnName", c => c.String(maxLength: 40));
            AddColumn("dbo.Member", "CifClientId", c => c.String(maxLength: 36));
            AddColumn("dbo.Member", "CifAddr", c => c.String(maxLength: 30));
            AddColumn("dbo.Member", "MerchantID", c => c.Long(nullable: false));
            AddColumn("dbo.BankCard", "Verified", c => c.Int(nullable: false));
            AddColumn("dbo.BankCard", "BankName", c => c.String(nullable: false, maxLength: 32));
            DropForeignKey("dbo.BankCard", "BankID", "dbo.Bank");
            DropIndex("dbo.Member", new[] { "IDNumber" });
            DropIndex("dbo.Bank", new[] { "Code" });
            DropIndex("dbo.BankCard", new[] { "BankID" });
            DropIndex("dbo.BankCard", new[] { "BankCardNumber" });
            AlterColumn("dbo.Member", "Mobile", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.Member", "IDNumber", c => c.String(maxLength: 32));
            AlterColumn("dbo.BankCard", "SubBranchName", c => c.String(nullable: false, maxLength: 32));
            DropColumn("dbo.Member", "PostCode");
            DropColumn("dbo.Member", "IdExpiredDate");
            DropColumn("dbo.Member", "EnName");
            DropColumn("dbo.Member", "ClientId");
            DropColumn("dbo.Member", "Address");
            DropColumn("dbo.BankCard", "BankID");
            DropColumn("dbo.BankCard", "Mobile");
            DropTable("dbo.Bank");
        }
    }
}
