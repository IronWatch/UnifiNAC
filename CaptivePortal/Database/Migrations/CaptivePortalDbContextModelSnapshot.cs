﻿// <auto-generated />
using System;
using CaptivePortal.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaptivePortal.Database.Migrations
{
    [DbContext(typeof(CaptivePortalDbContext))]
    partial class CaptivePortalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("CaptivePortal.Database.Entities.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountingSessionId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Authorized")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("AuthorizedUntil")
                        .HasColumnType("TEXT");

                    b.Property<string>("CallingStationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DetectedDeviceIpAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeviceMac")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeviceNetworkId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NasIdentifier")
                        .HasColumnType("TEXT");

                    b.Property<string>("NasIpAddress")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("CaptivePortal.Database.Entities.DeviceNetwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AssignedDeviceAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DeviceId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LeaseExpiresAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LeaseIssuedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ManuallyAssignedAddress")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NetworkId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId")
                        .IsUnique();

                    b.HasIndex("NetworkId");

                    b.ToTable("DeviceNetworks");
                });

            modelBuilder.Entity("CaptivePortal.Database.Entities.Network", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cidr")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GatewayAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NetworkAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Vlan")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Networks");
                });

            modelBuilder.Entity("CaptivePortal.Database.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ChangePasswordNextLogin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsStaff")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CaptivePortal.Database.Entities.UserSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RefreshTokenExpiresAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RefreshTokenIssuedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("CaptivePortal.Database.Entities.Device", b =>
                {
                    b.HasOne("CaptivePortal.Database.Entities.User", "User")
                        .WithMany("Devices")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CaptivePortal.Database.Entities.DeviceNetwork", b =>
                {
                    b.HasOne("CaptivePortal.Database.Entities.Device", "Device")
                        .WithOne("DeviceNetwork")
                        .HasForeignKey("CaptivePortal.Database.Entities.DeviceNetwork", "DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaptivePortal.Database.Entities.Network", "Network")
                        .WithMany("DeviceNetworks")
                        .HasForeignKey("NetworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Network");
                });

            modelBuilder.Entity("CaptivePortal.Database.Entities.UserSession", b =>
                {
                    b.HasOne("CaptivePortal.Database.Entities.User", "User")
                        .WithMany("UserSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CaptivePortal.Database.Entities.Device", b =>
                {
                    b.Navigation("DeviceNetwork");
                });

            modelBuilder.Entity("CaptivePortal.Database.Entities.Network", b =>
                {
                    b.Navigation("DeviceNetworks");
                });

            modelBuilder.Entity("CaptivePortal.Database.Entities.User", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("UserSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
