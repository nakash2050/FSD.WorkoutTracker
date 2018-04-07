namespace WorkoutTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStartTimeToWorkoutTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "StartTime", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "StartTime");
        }
    }
}
