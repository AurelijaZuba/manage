namespace manage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePhones : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Phone", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Phone", c => c.String());
        }
    }
}
