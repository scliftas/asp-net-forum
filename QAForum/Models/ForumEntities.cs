namespace QAForum.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ForumEntities : DbContext
    {
        public ForumEntities()
            : base("name=ForumEntities")
        {
        }

        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Thread> Threads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Forum>()
                .HasMany(e => e.Threads)
                .WithRequired(e => e.Forum)
                .WillCascadeOnDelete(false);
        }
    }
}
