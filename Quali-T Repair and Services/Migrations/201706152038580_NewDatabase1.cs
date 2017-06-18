namespace Quali_T_Repair_and_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDatabase1 : DbMigration
    {
        public override void Up()
        {
            Sql("insert into CustomerTypes (Name, MemberShipFee, DiscountRate, Duration) values ('Prime', '250', 50, 10);");
            Sql("insert into CustomerTypes (Name, MemberShipFee, DiscountRate, Duration) values ('Standard', '150', 20, 5);");
        }
        
        public override void Down()
        {
        }
    }
}
