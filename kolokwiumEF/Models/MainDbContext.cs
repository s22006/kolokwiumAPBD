using Microsoft.EntityFrameworkCore;
using System;

namespace kolokwium_s22006.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MainDbContext()
        {
        }

        public DbSet<Musician> Musician { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Musician_Track> Musician_Track { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).IsRequired().HasMaxLength(50);

                e.HasData(
                    new MusicLabel
                    {
                        IdMusicLabel = 1,
                        Name = "Label nr 1"
                    },
                    new MusicLabel
                    {
                        IdMusicLabel = 2,
                        Name = "Label nr 2"
                    },
                    new MusicLabel
                    {
                        IdMusicLabel = 3,
                        Name = "Label nr 3"
                    }
                );
            });

            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                e.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                e.Property(e => e.Nickname).HasMaxLength(20);

                e.HasData(
                    new Musician
                    {
                        IdMusician = 1,
                        FirstName = "Adam",
                        LastName = "Nowak",
                        Nickname = "Nowaczek"
                    },
                    new Musician
                    {
                        IdMusician = 2,
                        FirstName = "Jan",
                        LastName = "Kowalski",
                        Nickname = "Kowal"
                    },
                    new Musician
                    {
                        IdMusician = 3,
                        FirstName = "Anna",
                        LastName = "Szymanska",
                        Nickname = "Szyma"
                    }
                );
            });

            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                e.Property(e => e.PublishDate).IsRequired();

                e.HasOne(e => e.MusicLabel).WithMany(e => e.Album).HasForeignKey(e => e.IdMusicLabel);

                e.HasData(
                    new Album
                    {
                        IdAlbum = 1,
                        AlbumName = "Album nr 1",
                        PublishDate = DateTime.Parse("2022-06-02"),
                        IdMusicLabel = 1
                    },
                    new Album
                    {
                        IdAlbum = 2,
                        AlbumName = "Album nr 2",
                        PublishDate = DateTime.Parse("2021-10-07"),
                        IdMusicLabel = 2
                    },
                    new Album
                    {
                        IdAlbum = 3,
                        AlbumName = "Album nr 3",
                        PublishDate = DateTime.Parse("2021-01-05"),
                        IdMusicLabel = 3
                    }
                );
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                e.Property(e => e.Duration).IsRequired();

                e.HasOne(e => e.Album).WithMany(e => e.Track).HasForeignKey(e => e.IdMusicAlbum);

                e.HasData(
                    new Track
                    {
                        IdTrack = 1,
                        TrackName = "Track nr 1",
                        Duration = 90,
                        IdMusicAlbum = 1
                    },
                    new Track
                    {
                        IdTrack = 2,
                        TrackName = "Track nr 2",
                        Duration = 67,
                        IdMusicAlbum = 2
                    },
                    new Track
                    {
                        IdTrack = 3,
                        TrackName = "Track nr 3",
                        Duration = 58,
                        IdMusicAlbum = 3
                    }
                );
            });

            modelBuilder.Entity<Musician_Track>(e =>
            {

                e.HasKey(e => new { e.IdMusician, e.IdTrack });

                e.HasOne(e => e.Musician).WithMany(e => e.Musician_Track).HasForeignKey(e => e.IdMusician);
                e.HasOne(e => e.Track).WithMany(e => e.Musician_Track).HasForeignKey(e => e.IdTrack);

                e.HasData(
                    new Musician_Track
                    {
                        IdMusician = 1,
                        IdTrack = 1
                    },
                    new Musician_Track
                    {
                        IdMusician = 2,
                        IdTrack = 2
                    },
                    new Musician_Track
                    {
                        IdMusician = 3,
                        IdTrack = 3
                    }
                );
            });
        }
    }
}
