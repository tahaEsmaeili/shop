namespace shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCustomerPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Password");
        }
    }
}
