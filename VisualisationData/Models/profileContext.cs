using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VisualisationData.Models
{
    public partial class profileContext : DbContext
    {
        public profileContext()
        {
        }

        public profileContext(DbContextOptions<profileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MainProfile> MainProfile { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<QType> QType { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Questioned> Questioned { get; set; }
        public virtual DbSet<Result> Result { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connString = string.Empty;
                try
                {
                    connString = DBUtils.GetDBConnectionString();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                optionsBuilder.UseMySql(connString, x => x.ServerVersion("8.0.13-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainProfile>(entity =>
            {
                entity.ToTable("main_profile");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profile");

                entity.HasIndex(e => e.MainProfileId)
                    .HasName("main_profile_id");

                entity.HasIndex(e => e.TypeId)
                    .HasName("type_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnName("answer")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.MainProfileId)
                    .HasColumnName("main_profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.MainProfile)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.MainProfileId)
                    .HasConstraintName("profile_ibfk_2");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("profile_ibfk_1");
            });

            modelBuilder.Entity<QType>(entity =>
            {
                entity.ToTable("q_type");

                entity.HasIndex(e => e.Type)
                    .HasName("type")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.HasIndex(e => e.ProfileId)
                    .HasName("profile_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.LeftLimit)
                    .HasColumnName("left_limit")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RightLimit)
                    .HasColumnName("right_limit")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("question_ibfk_1");
            });

            modelBuilder.Entity<Questioned>(entity =>
            {
                entity.ToTable("questioned");

                entity.HasIndex(e => e.MainProfileId)
                    .HasName("main_profile_id");

                entity.HasIndex(e => e.Number)
                    .HasName("number")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MainProfileId)
                    .HasColumnName("main_profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.HasOne(d => d.MainProfile)
                    .WithMany(p => p.Questioned)
                    .HasForeignKey(d => d.MainProfileId)
                    .HasConstraintName("questioned_ibfk_1");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("result");

                entity.HasIndex(e => e.ProfileId)
                    .HasName("profile_id");

                entity.HasIndex(e => e.QuestionId)
                    .HasName("question_id");

                entity.HasIndex(e => e.QuestionedId)
                    .HasName("questioned_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnName("answer")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuestionId)
                    .HasColumnName("question_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuestionedId)
                    .HasColumnName("questioned_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("result_ibfk_1");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("result_ibfk_2");

                entity.HasOne(d => d.Questioned)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.QuestionedId)
                    .HasConstraintName("result_ibfk_3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
