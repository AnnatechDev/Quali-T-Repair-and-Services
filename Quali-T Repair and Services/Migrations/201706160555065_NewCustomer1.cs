namespace Quali_T_Repair_and_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewCustomer1 : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Customers (Firstname, Lastname, Email, UserName, MobileNumber, DateOfBirth, Password, ConfirmPassword, MemberSince, IsActive, IsDeleted, BillingAddress, CustomerTypeId) values ('Kerri', 'Klimowski', 'kklimowski1@nps.gov', 'kklimowsk1', '421-2918', '1986-01-20', 'Password', 'Password', '2011-10-12', 'false', 'true', '3 Sunfield Avenue', 2);");
            Sql("insert into Customers (Firstname, Lastname, Email, UserName, MobileNumber, DateOfBirth, Password, ConfirmPassword, MemberSince, IsActive, IsDeleted, BillingAddress, CustomerTypeId) values ('Muhammad', 'Pamment', 'mpamment2@ucoz.com', 'mpamment2', '665-8372', '1972-07-24', 'Password', 'Password', '2016-07-05', 'true', 'false', '294 Stoughton Place', 1);");
            Sql("insert into Customers (Firstname, Lastname, Email, UserName, MobileNumber, DateOfBirth, Password, ConfirmPassword, MemberSince, IsActive, IsDeleted, BillingAddress, CustomerTypeId) values ('Niall', 'Ugoletti', 'nugoletti3@behance.net', 'nugoletti3', '584-3949', '1989-04-20', 'Password', 'Password', '2010-11-29', 'true', 'true', '8338 Forster Park', 2);");
            Sql("insert into Customers (Firstname, Lastname, Email, UserName, MobileNumber, DateOfBirth, Password, ConfirmPassword, MemberSince, IsActive, IsDeleted, BillingAddress, CustomerTypeId) values ('Barry', 'Heap', 'bheap4@intel.com', 'bheap4', '729-2354', '1970-12-26', 'Password', 'Password', '2011-09-19', 'false', 'true', '6842 Becker Parkway', 2);");

        }

        public override void Down()
        {
        }
    }
}
