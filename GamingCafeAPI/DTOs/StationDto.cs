namespace GamingCafeAPI.DTOs
{
    public class StationDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? User { get; set; }
        public string SessionDuration { get; set; } = "0m";
        public string IpAddress { get; set; } = string.Empty;
        public int Cpu { get; set; }
        public int Ram { get; set; }
        public int Gpu { get; set; }
    }

    public class DashboardDto
    {
        public int ActiveStations { get; set; }
        public decimal TodayRevenue { get; set; }
        public int NetworkUsage { get; set; }
        public ServerStatusDto ServerStatus { get; set; } = new();
        public List<StationDto> Stations { get; set; } = new();
    }

    public class ServerStatusDto
    {
        public int Cpu { get; set; }
        public int Ram { get; set; }
        public int Disk { get; set; }
        public int Network { get; set; }
        public string Uptime { get; set; } = string.Empty;
    }
}