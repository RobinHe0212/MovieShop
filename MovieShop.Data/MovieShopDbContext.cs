﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entity;

namespace MovieShop.Data
{
   public class MovieShopDbContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Cast> Casts { get; set; }

        public DbSet<Crew> Crews { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<MovieCrew> MovieCrews { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Trailer> Trailers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<MovieCast> MovieCasts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Movies)
                .WithMany(e => e.Genres)
                .Map(m => m.ToTable("MovieGenre").MapLeftKey("GenreId").MapRightKey("MovieId"));

            modelBuilder.Entity<Movie>()
                .Property(e => e.Price)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Review>()
               .Property(e => e.Rating)
               .HasPrecision(3, 2);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users)
                .Map(m => m.ToTable("UserRole").MapLeftKey("UserId").MapRightKey("RoleId"));
        }
    }
}
