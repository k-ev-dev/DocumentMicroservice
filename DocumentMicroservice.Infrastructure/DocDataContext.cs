using Microsoft.EntityFrameworkCore;
using DocumentMicroservice.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentMicroservice.Infrastructure {
    public class DocDataContext : DbContext {

        public DbSet<Document> Documents { get; set; }


        public DocDataContext(DbContextOptions options) : base(options) {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }
    }
}
