﻿// <auto-generated />
using System;
using GamingCafeAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GamingCafeAPI.Migrations
{
    [DbContext(typeof(GamingCafeContext))]
    [Migration("20250720094352_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("GamingCafeAPI.Models.GamingStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CpuUsage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GpuUsage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<int>("RamUsage")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("SessionDuration")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("SessionStartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GamingStations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CpuUsage = 50,
                            GpuUsage = 72,
                            IpAddress = "192.168.100.101",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8315),
                            RamUsage = 68,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            SessionStartTime = new DateTime(2025, 7, 20, 8, 43, 51, 290, DateTimeKind.Utc).AddTicks(8362),
                            Status = "Gaming",
                            User = "Player_01"
                        },
                        new
                        {
                            Id = 2,
                            CpuUsage = 71,
                            GpuUsage = 90,
                            IpAddress = "192.168.100.102",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8372),
                            RamUsage = 78,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            SessionStartTime = new DateTime(2025, 7, 20, 7, 43, 51, 290, DateTimeKind.Utc).AddTicks(8374),
                            Status = "Gaming",
                            User = "Player_02"
                        },
                        new
                        {
                            Id = 3,
                            CpuUsage = 71,
                            GpuUsage = 74,
                            IpAddress = "192.168.100.103",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8374),
                            RamUsage = 70,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            SessionStartTime = new DateTime(2025, 7, 20, 7, 43, 51, 290, DateTimeKind.Utc).AddTicks(8376),
                            Status = "Gaming",
                            User = "Player_03"
                        },
                        new
                        {
                            Id = 4,
                            CpuUsage = 44,
                            GpuUsage = 72,
                            IpAddress = "192.168.100.104",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8376),
                            RamUsage = 72,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            SessionStartTime = new DateTime(2025, 7, 20, 7, 43, 51, 290, DateTimeKind.Utc).AddTicks(8377),
                            Status = "Gaming",
                            User = "Player_04"
                        },
                        new
                        {
                            Id = 5,
                            CpuUsage = 43,
                            GpuUsage = 94,
                            IpAddress = "192.168.100.105",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8378),
                            RamUsage = 84,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            SessionStartTime = new DateTime(2025, 7, 20, 8, 43, 51, 290, DateTimeKind.Utc).AddTicks(8379),
                            Status = "Gaming",
                            User = "Player_05"
                        },
                        new
                        {
                            Id = 6,
                            CpuUsage = 57,
                            GpuUsage = 73,
                            IpAddress = "192.168.100.106",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8380),
                            RamUsage = 74,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            SessionStartTime = new DateTime(2025, 7, 20, 7, 43, 51, 290, DateTimeKind.Utc).AddTicks(8385),
                            Status = "Gaming",
                            User = "Player_06"
                        },
                        new
                        {
                            Id = 7,
                            CpuUsage = 52,
                            GpuUsage = 80,
                            IpAddress = "192.168.100.107",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8385),
                            RamUsage = 66,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            SessionStartTime = new DateTime(2025, 7, 20, 7, 43, 51, 290, DateTimeKind.Utc).AddTicks(8387),
                            Status = "Gaming",
                            User = "Player_07"
                        },
                        new
                        {
                            Id = 8,
                            CpuUsage = 67,
                            GpuUsage = 81,
                            IpAddress = "192.168.100.108",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8387),
                            RamUsage = 64,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            SessionStartTime = new DateTime(2025, 7, 20, 8, 43, 51, 290, DateTimeKind.Utc).AddTicks(8388),
                            Status = "Gaming",
                            User = "Player_08"
                        },
                        new
                        {
                            Id = 9,
                            CpuUsage = 11,
                            GpuUsage = 15,
                            IpAddress = "192.168.100.109",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8389),
                            RamUsage = 26,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            Status = "Online"
                        },
                        new
                        {
                            Id = 10,
                            CpuUsage = 22,
                            GpuUsage = 5,
                            IpAddress = "192.168.100.110",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8392),
                            RamUsage = 24,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            Status = "Online"
                        },
                        new
                        {
                            Id = 11,
                            CpuUsage = 24,
                            GpuUsage = 10,
                            IpAddress = "192.168.100.111",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8396),
                            RamUsage = 20,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            Status = "Online"
                        },
                        new
                        {
                            Id = 12,
                            CpuUsage = 20,
                            GpuUsage = 18,
                            IpAddress = "192.168.100.112",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8397),
                            RamUsage = 27,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            Status = "Online"
                        },
                        new
                        {
                            Id = 13,
                            CpuUsage = 24,
                            GpuUsage = 6,
                            IpAddress = "192.168.100.113",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8398),
                            RamUsage = 33,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            Status = "Online"
                        },
                        new
                        {
                            Id = 14,
                            CpuUsage = 21,
                            GpuUsage = 19,
                            IpAddress = "192.168.100.114",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8399),
                            RamUsage = 38,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            Status = "Online"
                        },
                        new
                        {
                            Id = 15,
                            CpuUsage = 13,
                            GpuUsage = 12,
                            IpAddress = "192.168.100.115",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8400),
                            RamUsage = 35,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            Status = "Online"
                        },
                        new
                        {
                            Id = 16,
                            CpuUsage = 19,
                            GpuUsage = 15,
                            IpAddress = "192.168.100.116",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8401),
                            RamUsage = 21,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            Status = "Offline"
                        },
                        new
                        {
                            Id = 17,
                            CpuUsage = 24,
                            GpuUsage = 18,
                            IpAddress = "192.168.100.117",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8403),
                            RamUsage = 37,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            Status = "Offline"
                        },
                        new
                        {
                            Id = 18,
                            CpuUsage = 10,
                            GpuUsage = 8,
                            IpAddress = "192.168.100.118",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8404),
                            RamUsage = 31,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            Status = "Offline"
                        },
                        new
                        {
                            Id = 19,
                            CpuUsage = 15,
                            GpuUsage = 10,
                            IpAddress = "192.168.100.119",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8405),
                            RamUsage = 33,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            Status = "Offline"
                        },
                        new
                        {
                            Id = 20,
                            CpuUsage = 14,
                            GpuUsage = 6,
                            IpAddress = "192.168.100.120",
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8406),
                            RamUsage = 30,
                            SessionDuration = new TimeSpan(0, 0, 0, 0, 0),
                            Status = "Offline"
                        });
                });

            modelBuilder.Entity("GamingCafeAPI.Models.ServerStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CpuUsage")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DhcpRunning")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiskUsage")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HttpRunning")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IscsiRunning")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<bool>("MonitoringRunning")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NetworkUsage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RamUsage")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TftpRunning")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Uptime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ServerStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CpuUsage = 65,
                            DhcpRunning = true,
                            DiskUsage = 45,
                            HttpRunning = true,
                            IscsiRunning = true,
                            LastUpdated = new DateTime(2025, 7, 20, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8478),
                            MonitoringRunning = true,
                            NetworkUsage = 82,
                            RamUsage = 78,
                            TftpRunning = true,
                            Uptime = new DateTime(2025, 7, 10, 9, 43, 51, 290, DateTimeKind.Utc).AddTicks(8480)
                        });
                });

            modelBuilder.Entity("GamingCafeAPI.Models.UserSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("StationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("GamingCafeAPI.Models.UserSession", b =>
                {
                    b.HasOne("GamingCafeAPI.Models.GamingStation", "Station")
                        .WithMany("Sessions")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");
                });

            modelBuilder.Entity("GamingCafeAPI.Models.GamingStation", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
