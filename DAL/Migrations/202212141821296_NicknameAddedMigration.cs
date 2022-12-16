namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NicknameAddedMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "nickname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "nickname");
        }
    }
}
