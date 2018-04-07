namespace WorkoutTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStartDateToWorkoutTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "StartDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "StartDate");
        }
    }
}
