namespace AcunMedya.Restaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSurnameAndTitleToAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Surname", c => c.String());
            AddColumn("dbo.Admins", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Title");
            DropColumn("dbo.Admins", "Surname");
        }
    }
}
