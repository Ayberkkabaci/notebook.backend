using Microsoft.EntityFrameworkCore;

namespace notebook.backend.Models
{
    public class NotebookContext : DbContext
    {
        public NotebookContext()
        {
        }

        public NotebookContext(DbContextOptions<NotebookContext> options)
            : base(options)
        {
        }

        public DbSet<Folder> Folder { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>(entity =>
            {
                entity.ToTable("folder", "notebook");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_folder_user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedOn).HasColumnName("createdOn");

                entity.Property(e => e.ModifiedOn).HasColumnName("modifiedOn");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Folder)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_folder_user");
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.ToTable("notes", "notebook");

                entity.HasIndex(e => e.PageId)
                    .HasName("FK_notes_pages");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnName("createdOn");

                entity.Property(e => e.IsPrivate)
                    .HasColumnName("isPrivate")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ModifiedOn).HasColumnName("modifiedOn");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PageId)
                    .HasColumnName("pageId")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_notes_pages");
            });

            modelBuilder.Entity<Pages>(entity =>
            {
                entity.ToTable("pages", "notebook");

                entity.HasIndex(e => e.FolderId)
                    .HasName("FK_pages_folder");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedOn).HasColumnName("createdOn");

                entity.Property(e => e.FolderId)
                    .HasColumnName("folderId")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ModifiedOn).HasColumnName("modifiedOn");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.Pages)
                    .HasForeignKey(d => d.FolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pages_folder");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users", "notebook");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.CreatedOn).HasColumnName("createdOn");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
