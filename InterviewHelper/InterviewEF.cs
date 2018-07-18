namespace InterviewHelper
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using InterviewHelper.Migrations;
    using InterviewHelper.Models;

    public partial class InterviewEF : DbContext
    {
        public InterviewEF()
            : base("name=InterviewEF")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<InterviewEF, Configuration>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Solution> Solutions { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
