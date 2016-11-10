namespace manage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePhoneNum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Phone", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Phone", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
