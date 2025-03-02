using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using testLinq.Model;

namespace testLinq.Connection;

public partial class Barkovskii2323dLearningDbContext : DbContext
{
    public Barkovskii2323dLearningDbContext()
    {
    }

    public Barkovskii2323dLearningDbContext(DbContextOptions<Barkovskii2323dLearningDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GamePlayer> GamePlayers { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=83.147.246.87:5432;Database=barkovskii_2323d_learning_db;Username=barkovskii_2323d_learning_user;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("authors_pkey");

            entity.ToTable("authors");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BirthYear).HasColumnName("birth_year");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("books_pkey");

            entity.ToTable("books");

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .HasColumnName("genre");
            entity.Property(e => e.Pages).HasColumnName("pages");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("books_author_id_fkey");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("games_pk");

            entity.ToTable("games");

            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Genre)
                .HasMaxLength(100)
                .HasColumnName("genre");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ReleaseYear).HasColumnName("release_year");
        });

        modelBuilder.Entity<GamePlayer>(entity =>
        {
            entity.HasKey(e => new { e.GameId, e.PlayerId }).HasName("game_players_pkey");

            entity.ToTable("game_players");

            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.HoursPlayed).HasColumnName("hours_played");

            entity.HasOne(d => d.Game).WithMany(p => p.GamePlayers)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("game_players_games_id_fk");

            entity.HasOne(d => d.Player).WithMany(p => p.GamePlayers)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("game_players_id_fk");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("players_pk");

            entity.ToTable("players");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("table_name_pkey");

            entity.ToTable("todo");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('table_name_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedTime)
                .HasMaxLength(100)
                .HasColumnName("created_time");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
