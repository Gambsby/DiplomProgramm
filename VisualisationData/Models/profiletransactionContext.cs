using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VisualisationData.Models
{
    public partial class profiletransactionContext : DbContext
    {
        public profiletransactionContext()
        {
        }

        public profiletransactionContext(DbContextOptions<profiletransactionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Limits> Limits { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public virtual DbSet<Questioned> Questioned { get; set; }
        public virtual DbSet<Questiontype> Questiontype { get; set; }
        public virtual DbSet<Result> Result { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseMySql("server=remotemysql.com;port=3306;user=xVpoPVpBoJ;password=e9ji45qzRZ;database=xVpoPVpBoJ", x => x.ServerVersion("5.6.41-mysql"));
                optionsBuilder.UseMySql("server=localhost;port=3306;user=mysql;password=mysql;database=profiletransaction", x => x.ServerVersion("5.6.41-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("answer");

                entity.HasIndex(e => e.ProfileId)
                    .HasName("profile_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("answer_ibfk_1");
            });

            modelBuilder.Entity<Limits>(entity =>
            {
                entity.ToTable("limits");

                entity.HasIndex(e => e.ProfileId)
                    .HasName("profile_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.End)
                    .IsRequired()
                    .HasColumnName("end")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Start)
                    .IsRequired()
                    .HasColumnName("start")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Limits)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("limits_ibfk_1");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profile");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.HasIndex(e => e.LimitsId)
                    .HasName("question_ibfk_3");

                entity.HasIndex(e => e.ProfileId)
                    .HasName("question_ibfk_1");

                entity.HasIndex(e => e.TypeId)
                    .HasName("type_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LimitsId)
                    .HasColumnName("limits_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Limits)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.LimitsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("question_ibfk_3");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("question_ibfk_1");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("question_ibfk_2");
            });

            modelBuilder.Entity<QuestionAnswer>(entity =>
            {
                entity.ToTable("question_answer");

                entity.HasIndex(e => e.AnswerId)
                    .HasName("answer_id");

                entity.HasIndex(e => e.QuestionId)
                    .HasName("question_answer_ibfk_2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AnswerId)
                    .HasColumnName("answer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuestionId)
                    .HasColumnName("question_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.QuestionAnswer)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("question_answer_ibfk_1");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("question_answer_ibfk_2");
            });

            modelBuilder.Entity<Questioned>(entity =>
            {
                entity.ToTable("questioned");

                entity.HasIndex(e => e.Number)
                    .HasName("number")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Questiontype>(entity =>
            {
                entity.ToTable("questiontype");

                entity.HasIndex(e => e.Type)
                    .HasName("type")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(16)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("result");

                entity.HasIndex(e => e.QuestionAnswerId)
                    .HasName("result_ibfk_2");

                entity.HasIndex(e => e.QuestionedId)
                    .HasName("result_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuestionAnswerId)
                    .HasColumnName("question_answer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuestionedId)
                    .HasColumnName("questioned_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.QuestionAnswer)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.QuestionAnswerId)
                    .HasConstraintName("result_ibfk_2");

                entity.HasOne(d => d.Questioned)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.QuestionedId)
                    .HasConstraintName("result_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
