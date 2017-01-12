namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SOYMModel : DbContext
    {
        public SOYMModel()
            : base("name=SOYMDB")
        {
        }

        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Mail> Mails { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Pupil> Pupils { get; set; }
        public virtual DbSet<Requisition> Requisitions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRoom>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ClassRoom>()
                .HasMany(e => e.Pupils)
                .WithMany(e => e.ClassRooms)
                .Map(m => m.ToTable("Pupil_ClassRoom").MapLeftKey("ClassRooms_Id").MapRightKey("Pupils_Id"));

            modelBuilder.Entity<ClassRoom>()
                .HasMany(e => e.Teachers)
                .WithMany(e => e.ClassRooms)
                .Map(m => m.ToTable("Teacher_ClassRoom").MapLeftKey("ClassRooms_Id").MapRightKey("Teachers_Id"));

            modelBuilder.Entity<Comment>()
                .Property(e => e.CommentUser)
                .IsUnicode(false);

            modelBuilder.Entity<Mail>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .Property(e => e.PlaceOfWork)
                .IsUnicode(false);

            modelBuilder.Entity<Parent>()
                .HasMany(e => e.Pupils)
                .WithMany(e => e.Parents)
                .Map(m => m.ToTable("Pupil_Parent").MapLeftKey("Parents_Id").MapRightKey("Pupils_Id"));

            modelBuilder.Entity<Pupil>()
                .Property(e => e.School)
                .IsUnicode(false);

            modelBuilder.Entity<Pupil>()
                .Property(e => e.ClassLetter)
                .IsUnicode(false);

            modelBuilder.Entity<Pupil>()
                .Property(e => e.SchoolTeacherSurname)
                .IsUnicode(false);

            modelBuilder.Entity<Requisition>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Requisition>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Requisition>()
                .Property(e => e.Patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<Requisition>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Requisition>()
                .Property(e => e.District)
                .IsUnicode(false);

            modelBuilder.Entity<Requisition>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("User_Role").MapLeftKey("Roles_Id").MapRightKey("Users_Id"));

            modelBuilder.Entity<Teacher>()
                .Property(e => e.WorkPlace)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Pupils)
                .WithOptional(e => e.Teacher)
                .HasForeignKey(e => e.IdTeacher);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.District)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Mails)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Parents)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Pupils)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Teachers)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);
        }
    }
}
