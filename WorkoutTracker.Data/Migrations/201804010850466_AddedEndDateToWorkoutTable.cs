namespace WorkoutTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEndDateToWorkoutTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "EndDate");
        }
    }
}
