namespace GamingCafeAPI.Models
{
    public class ServerStatus
    {
        public int Id { get; set; }
        public int CpuUsage { get; set; }
        public int RamUsage { get; set; }
        public int DiskUsage { get; set; }
        public int NetworkUsage { get; set; }
        public DateTime Uptime { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        
        public bool DhcpRunning { get; set; } = true;
        public bool TftpRunning { get; set; } = true;
        public bool IscsiRunning { get; set; } = true;
        public bool HttpRunning { get; set; } = true;
        public bool MonitoringRunning { get; set; } = true;
    }
}