using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamingCafeAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GamingStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    User = table.Column<string>(type: "TEXT", nullable: true),
                    SessionDuration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    IpAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CpuUsage = table.Column<int>(type: "INTEGER", nullable: false),
                    RamUsage = table.Column<int>(type: "INTEGER", nullable: false),
                    GpuUsage = table.Column<int>(type: "INTEGER", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SessionStartTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServerStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CpuUsage = table.Column<int>(type: "INTEGER", nullable: false),
                    RamUsage = table.Column<int>(type: "INTEGER", nullable: false),
                    DiskUsage = table.Column<int>(type: "INTEGER", nullable: false),
                    NetworkUsage = table.Column<int>(type: "INTEGER", nullable: false),
                    Uptime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DhcpRunning = table.Column<bool>(type: "INTEGER", nullable: false),
                    TftpRunning = table.Column<bool>(type: "INTEGER", nullable: false),
                    IscsiRunning = table.Column<bool>(type: "INTEGER", nullable: false),
                    HttpRunning = table.Column<bool>(type: "INTEGER", nullable: false),
                    MonitoringRunning = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StationId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessions_GamingStations_StationId",
                        column: x => x.StationId,
                        principalTable: "GamingStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GamingStations",
                columns: new[] { "Id", "CpuUsage", "GpuUsage", "IpAddress", "LastUpdated", "RamUsage", "SessionDuration", "SessionStartTime", "Status", "User" },
                values: new object[,]
                {
                    { 1, 50, 72, "192.168.100.101", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8315), 68, new TimeSpan(0, 0, 0, 0, 0), new DateTime(2025, 7, 20, 8, 43, 51, 290, DateTimeKind.Utc).AddTicks(8362), "Gaming", "Player_01" },
                    { 2, 71, 90, "192.168.100.102", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8372), 78, new TimeSpan(0, 0, 0, 0, 0), new DateTime(2025, 7, 20, 7, 43, 51, 290, DateTimeKind.Utc).AddTicks(8374), "Gaming", "Player_02" },
                    { 3, 71, 74, "192.168.100.103", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8374), 70, new TimeSpan(0, 0, 0, 0, 0), new DateTime(2025, 7, 20, 7, 43, 51, 290, DateTimeKind.Utc).AddTicks(8376), "Gaming", "Player_03" },
                    { 4, 44, 72, "192.168.100.104", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8376), 72, new TimeSpan(0, 0, 0, 0, 0), new DateTime(2025, 7, 20, 7, 43, 51, 290, DateTimeKind.Utc).AddTicks(8377), "Gaming", "Player_04" },
                    { 5, 43, 94, "192.168.100.105", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8378), 84, new TimeSpan(0, 0, 0, 0, 0), new DateTime(2025, 7, 20, 8, 43, 51, 290, DateTimeKind.Utc).AddTicks(8379), "Gaming", "Player_05" },
                    { 6, 57, 73, "192.168.100.106", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8380), 74, new TimeSpan(0, 0, 0, 0, 0), new DateTime(2025, 7, 20, 7, 43, 51, 290, DateTimeKind.Utc).AddTicks(8385), "Gaming", "Player_06" },
                    { 7, 52, 80, "192.168.100.107", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8385), 66, new TimeSpan(0, 0, 0, 0, 0), new DateTime(2025, 7, 20, 7, 43, 51, 290, DateTimeKind.Utc).AddTicks(8387), "Gaming", "Player_07" },
                    { 8, 67, 81, "192.168.100.108", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8387), 64, new TimeSpan(0, 0, 0, 0, 0), new DateTime(2025, 7, 20, 8, 43, 51, 290, DateTimeKind.Utc).AddTicks(8388), "Gaming", "Player_08" },
                    { 9, 11, 15, "192.168.100.109", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8389), 26, new TimeSpan(0, 0, 0, 0, 0), null, "Online", null },
                    { 10, 22, 5, "192.168.100.110", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8392), 24, new TimeSpan(0, 0, 0, 0, 0), null, "Online", null },
                    { 11, 24, 10, "192.168.100.111", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8396), 20, new TimeSpan(0, 0, 0, 0, 0), null, "Online", null },
                    { 12, 20, 18, "192.168.100.112", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8397), 27, new TimeSpan(0, 0, 0, 0, 0), null, "Online", null },
                    { 13, 24, 6, "192.168.100.113", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8398), 33, new TimeSpan(0, 0, 0, 0, 0), null, "Online", null },
                    { 14, 21, 19, "192.168.100.114", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8399), 38, new TimeSpan(0, 0, 0, 0, 0), null, "Online", null },
                    { 15, 13, 12, "192.168.100.115", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8400), 35, new TimeSpan(0, 0, 0, 0, 0), null, "Online", null },
                    { 16, 19, 15, "192.168.100.116", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8401), 21, new TimeSpan(0, 0, 0, 0, 0), null, "Offline", null },
                    { 17, 24, 18, "192.168.100.117", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8403), 37, new TimeSpan(0, 0, 0, 0, 0), null, "Offline", null },
                    { 18, 10, 8, "192.168.100.118", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8404), 31, new TimeSpan(0, 0, 0, 0, 0), null, "Offline", null },
                    { 19, 15, 10, "192.168.100.119", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8405), 33, new TimeSpan(0, 0, 0, 0, 0), null, "Offline", null },
                    { 20, 14, 6, "192.168.100.120", new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8406), 30, new TimeSpan(0, 0, 0, 0, 0), null, "Offline", null }
                });

            migrationBuilder.InsertData(
                table: "ServerStatus",
                columns: new[] { "Id", "CpuUsage", "DhcpRunning", "DiskUsage", "HttpRunning", "IscsiRunning", "LastUpdated", "MonitoringRunning", "NetworkUsage", "RamUsage", "TftpRunning", "Uptime" },
                values: new object[] { 1, 65, true, 45, true, true, new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8478), true, 82, 78, true, new DateTime(2025, 7, 10, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8480) });

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_StationId",
                table: "UserSessions",
                column: "StationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServerStatus");

            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "GamingStations");
        }
    }
}
