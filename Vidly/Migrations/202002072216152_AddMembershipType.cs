namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFree = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Index", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Index", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Index", "MembershipTypeId");
            AddForeignKey("dbo.Index", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Index", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Index", new[] { "MembershipTypeId" });
            DropColumn("dbo.Index", "MembershipTypeId");
            DropColumn("dbo.Index", "IsSubscribedToNewsletter");
            DropTable("dbo.MembershipTypes");
        }
    }
}
