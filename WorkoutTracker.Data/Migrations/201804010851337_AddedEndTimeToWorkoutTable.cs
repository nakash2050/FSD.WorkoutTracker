namespace WorkoutTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEndTimeToWorkoutTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "EndTime", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "EndTime");
        }
    }
}
