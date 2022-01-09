
using System;
using Microsoft.EntityFrameworkCore;

namespace ecosystem_smart_home_rest_api
{
    public class SmartHomeContext : DbContext
    {
        public DbSet<RoomInfo> RoomInfo { get; set; }
        
        public SmartHomeContext(DbContextOptions<SmartHomeContext> options) : base(options) 
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine);
        }
        
    }
}