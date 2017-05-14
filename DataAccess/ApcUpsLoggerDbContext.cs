using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ApcUpsLogger.DataAccess.Entities;

namespace ApcUpsLogger.DataAccess
{
    public class ApcUpsLoggerDbContext : DbContext
    {
        public ApcUpsLoggerDbContext(DbContextOptions<ApcUpsLoggerDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<LineVoltage> LineVoltages { get; set; }
    }
}
