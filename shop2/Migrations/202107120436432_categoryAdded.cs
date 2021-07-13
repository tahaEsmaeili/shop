namespace shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 100));
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Categories", "Name", c => c.String(maxLength: 100));
        }
    }
}
