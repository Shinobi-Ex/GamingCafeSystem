using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamingCafeAPI.Data;
using GamingCafeAPI.DTOs;

namespace GamingCafeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly GamingCafeContext _context;

        public DashboardController(GamingCafeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            var stations = await _context.GamingStations.ToListAsync();
            var serverStatus = await _context.ServerStatus.FirstOrDefaultAsync() ?? new Models.ServerStatus();

            var stationDtos = stations.Select(s => new StationDto
            {
                Id = s.Id,
                Status = s.Status,
                User = s.User,
                SessionDuration = s.SessionStartTime.HasValue 
                    ? FormatDuration(DateTime.UtcNow - s.SessionStartTime.Value) 
                    : "0m",
                IpAddress = s.IpAddress,
                Cpu = s.CpuUsage,
                Ram = s.RamUsage,
                Gpu = s.GpuUsage
            }).ToList();

            var dashboard = new DashboardDto
            {
                ActiveStations = stations.Count(s => s.Status == "Gaming" || s.Status == "Online"),
                TodayRevenue = 2847m, // Sample revenue - you can calculate this from sessions
                NetworkUsage = serverStatus.NetworkUsage,
                ServerStatus = new ServerStatusDto
                {
                    Cpu = serverStatus.CpuUsage,
                    Ram = serverStatus.RamUsage,
                    Disk = serverStatus.DiskUsage,
                    Network = serverStatus.NetworkUsage,
                    Uptime = FormatDuration(DateTime.UtcNow - serverStatus.Uptime)
                },
                Stations = stationDtos
            };

            return Ok(dashboard);
        }

        private string FormatDuration(TimeSpan duration)
        {
            if (duration.TotalDays >= 1)
                return $"{(int)duration.TotalDays}d {duration.Hours}h {duration.Minutes}m";
            else if (duration.TotalHours >= 1)
                return $"{(int)duration.TotalHours}h {duration.Minutes}m";
            else
                return $"{duration.Minutes}m";
        }
    }
}