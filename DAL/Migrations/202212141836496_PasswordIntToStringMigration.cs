namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordIntToStringMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.users", "password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.users", "password", c => c.Long(nullable: false));
        }
    }
}
