namespace WorkoutTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNoteColumnToWorkoutTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "Note");
        }
    }
}
