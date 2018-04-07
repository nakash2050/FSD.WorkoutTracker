namespace WorkoutTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCalorieBurntPerMinToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workouts", "CalorieBurntPerMin", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workouts", "CalorieBurntPerMin", c => c.Int(nullable: false));
        }
    }
}
