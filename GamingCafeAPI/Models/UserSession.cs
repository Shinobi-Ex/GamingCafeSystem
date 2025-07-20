namespace GamingCafeAPI.Models
{
    public class UserSession
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal Cost { get; set; }
        public bool IsActive { get; set; }
        
        public GamingStation Station { get; set; } = null!;
    }
}