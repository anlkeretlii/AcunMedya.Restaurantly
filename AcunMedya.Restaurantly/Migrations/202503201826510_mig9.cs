﻿namespace AcunMedya.Restaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Title");
        }
    }
}
