namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres values( 'Action')");
            Sql("insert into Genres values('Comedy')");
            Sql("insert into Genres values('Family')");
            Sql("insert into Genres values('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
