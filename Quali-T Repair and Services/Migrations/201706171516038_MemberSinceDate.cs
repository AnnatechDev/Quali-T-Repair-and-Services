namespace Quali_T_Repair_and_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberSinceDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "MemberSince", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "MemberSince", c => c.DateTime());
        }
    }
}
