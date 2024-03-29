﻿using Character.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Repository
{
    public class CharacterDbContext : DbContext
    {
        public CharacterDbContext(DbContextOptions<CharacterDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterDb>().HasKey(p => p.ID);
            modelBuilder.Entity<CharacterDb>().Property(p => p.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<TransactionalOutbox>().HasKey(e => new { e.ID });
            modelBuilder.Entity<TransactionalOutbox>().Property(e => e.ID).ValueGeneratedOnAdd();
        }

        public DbSet<CharacterDb> CharacterDb { get; set; }
        public DbSet<TransactionalOutbox> TransitionalOutboxes { get; set; }
    }
}
