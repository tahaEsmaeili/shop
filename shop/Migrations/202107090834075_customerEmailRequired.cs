namespace shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerEmailRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Email", c => c.String(maxLength: 50));
        }
    }
}
