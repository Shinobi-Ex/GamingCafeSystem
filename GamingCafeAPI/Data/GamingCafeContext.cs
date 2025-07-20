using Microsoft.EntityFrameworkCore;
using GamingCafeAPI.Models;

namespace GamingCafeAPI.Data
{
    public class GamingCafeContext : DbContext
    {
        public GamingCafeContext(DbContextOptions<GamingCafeContext> options) : base(options) { }

        public DbSet<GamingStation> GamingStations { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<ServerStatus> ServerStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create 20 gaming stations with sample data
            var stations = new List<GamingStation>();
            var random = new Random();
            
            for (int i = 1; i <= 20; i++)
            {
                var status = i <= 8 ? "Gaming" : (i <= 15 ? "Online" : "Offline");
                stations.Add(new GamingStation
                {
                    Id = i,
                    Status = status,
                    User = status == "Gaming" ? $"Player_{i:D2}" : null,
                    IpAddress = $"192.168.100.{100 + i}",
                    CpuUsage = status == "Gaming" ? random.Next(40, 75) : random.Next(10, 25),
                    RamUsage = status == "Gaming" ? random.Next(60, 85) : random.Next(20, 40),
                    GpuUsage = status == "Gaming" ? random.Next(70, 95) : random.Next(5, 20),
                    SessionStartTime = status == "Gaming" ? DateTime.UtcNow.AddHours(-random.Next(1, 3)) : null
                });
            }

            modelBuilder.Entity<GamingStation>().HasData(stations);

            // Add initial server status
            modelBuilder.Entity<ServerStatus>().HasData(new ServerStatus
            {
                Id = 1,
                CpuUsage = 65,
                RamUsage = 78,
                DiskUsage = 45,
                NetworkUsage = 82,
                Uptime = DateTime.UtcNow.AddDays(-10)
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}