namespace shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1ce7cdc6-9a3d-4400-9ab3-7e7104569d36', N'guest@shop.com', 0, N'ANP2NfgoYlNRVuvY0hG4CQVRmAl8tp4vXhIx3smfDWo0KPRC6KAZkl5/wVgFed6+vw==', N'6f1c6e3a-e045-4dde-a237-aacb81e899a3', NULL, 0, 0, NULL, 1, 0, N'guest@shop.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'77a95d5f-4753-4921-98ab-8a9fbf26e1e7', N'admin@shop.com', 0, N'AFndTnnI4iPrCvRzyJVrlDRBBtVC75j3/7/UryLDgTSHl/cNsUb2UJTUxqxftIlCAw==', N'33cdb896-51d4-4f3c-8d1d-4a09c80b250c', NULL, 0, 0, NULL, 1, 0, N'admin@shop.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5a4a1cb7-514e-4397-89db-316d4d9a4a16', N'canManageProduct')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'77a95d5f-4753-4921-98ab-8a9fbf26e1e7', N'5a4a1cb7-514e-4397-89db-316d4d9a4a16')

");
        }
        
        public override void Down()
        {
        }
    }
}
