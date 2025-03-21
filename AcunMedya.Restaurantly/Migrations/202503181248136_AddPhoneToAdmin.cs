namespace AcunMedya.Restaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneToAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Phone");
        }
    }
}
