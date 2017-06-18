namespace Quali_T_Repair_and_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberSinceDate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "MemberSince", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "MemberSince", c => c.DateTime(nullable: false));
        }
    }
}
