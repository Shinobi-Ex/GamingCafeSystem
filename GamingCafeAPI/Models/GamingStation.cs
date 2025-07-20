using System.ComponentModel.DataAnnotations;

namespace GamingCafeAPI.Models
{
    public class GamingStation
    {
        public int Id { get; set; }
        public string Status { get; set; } = "Offline";
        public string? User { get; set; }
        public TimeSpan SessionDuration { get; set; }
        public string IpAddress { get; set; } = string.Empty;
        public int CpuUsage { get; set; }
        public int RamUsage { get; set; }
        public int GpuUsage { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public DateTime? SessionStartTime { get; set; }
        
        public List<UserSession> Sessions { get; set; } = new();
    }
}