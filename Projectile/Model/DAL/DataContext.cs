using DomainModel;
using System.Data.Entity;

namespace DAL
{
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<boards> boards { get; set; }
        public virtual DbSet<cards> cards { get; set; }
        public virtual DbSet<priorities> priorities { get; set; }
        public virtual DbSet<projects> projects { get; set; }
        public virtual DbSet<statuses> statuses { get; set; }
        public virtual DbSet<tags> tags { get; set; }
        public virtual DbSet<tasks> tasks { get; set; }
        public virtual DbSet<todolists> todolists { get; set; }
        public virtual DbSet<todos> todos { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<boards>()
                .HasMany(e => e.cards)
                .WithOptional(e => e.boards)
                .HasForeignKey(e => e.cardboard);

            modelBuilder.Entity<boards>()
                .HasMany(e => e.users)
                .WithMany(e => e.boards)
                .Map(m => m.ToTable("board_user", "public").MapLeftKey("board").MapRightKey("userof"));

            modelBuilder.Entity<cards>()
                .HasMany(e => e.tasks)
                .WithOptional(e => e.cards)
                .HasForeignKey(e => e.taskcard);

            modelBuilder.Entity<priorities>()
                .HasMany(e => e.tasks)
                .WithOptional(e => e.priorities)
                .HasForeignKey(e => e.taskpriority);

            modelBuilder.Entity<projects>()
                .HasMany(e => e.boards)
                .WithOptional(e => e.projects)
                .HasForeignKey(e => e.boardproject);

            modelBuilder.Entity<statuses>()
                .HasMany(e => e.tasks)
                .WithOptional(e => e.statuses)
                .HasForeignKey(e => e.taskstatus);

            modelBuilder.Entity<tags>()
                .HasMany(e => e.tasks)
                .WithMany(e => e.tags)
                .Map(m => m.ToTable("task_tag", "public").MapLeftKey("tag").MapRightKey("task"));

            modelBuilder.Entity<tasks>()
                .HasMany(e => e.todolists)
                .WithOptional(e => e.tasks)
                .HasForeignKey(e => e.todolisttask);

            modelBuilder.Entity<todolists>()
                .HasMany(e => e.todos)
                .WithOptional(e => e.todolists)
                .HasForeignKey(e => e.todotodolist);

            modelBuilder.Entity<users>()
                .HasMany(e => e.projects)
                .WithOptional(e => e.users)
                .HasForeignKey(e => e.projectowner);

            modelBuilder.Entity<users>()
                .HasMany(e => e.tasks)
                .WithOptional(e => e.users)
                .HasForeignKey(e => e.taskchecker);

            modelBuilder.Entity<users>()
                .HasMany(e => e.tasks1)
                .WithOptional(e => e.users1)
                .HasForeignKey(e => e.worker);
        }
    }
}
