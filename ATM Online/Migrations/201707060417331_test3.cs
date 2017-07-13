namespace ATM_Online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransferViewModels",
                c => new
                    {
                        TransferViewModelId = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckingAccountId = c.Int(nullable: false),
                        DestinationAccountNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TransferViewModelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransferViewModels");
        }
    }
}
