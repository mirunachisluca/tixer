using Microsoft.EntityFrameworkCore;
using System;
using Tixer.Models;

namespace Tixer.Context
{
    public class TixerDbContext : DbContext
    {
        public TixerDbContext(DbContextOptions<TixerDbContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
