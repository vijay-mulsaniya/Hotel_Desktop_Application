using Hotel.Data.SeedData;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public AppDbContext()
        {
        }

        public DbSet<TblAddress> Addresses { get; set; } = null!;
        public DbSet<TblHotel> Hotels { get; set; } = null!;
        public DbSet<TblRoom> Rooms { get; set; } = null!;
        public DbSet<TblGuest> Guests { get; set; } = null!;
        public DbSet<TblIdentityProof> IdentityProofs { get; set; } = null!;
        public DbSet<TblRole> Roles { get; set; } = null!;
        public DbSet<TblUserRole> UserRoles { get; set; } = null!;
        public DbSet<TblUser> Users { get; set; } = null!;
        public DbSet<TblAminities> Aminities { get; set; } = null!;
        public DbSet<TblCleaning> Cleanings { get; set; } = null!;
        public DbSet<TblBookingMaster> BookingMasters { get; set; } = null!;
        public DbSet<TblRoomBooking> RoomBookings { get; set; } = null!;
        public DbSet<TblPayment> Payments { get; set; } = null!;
        public DbSet<TblFoodMenu> FoodMenus { get; set; } = null!;
        public DbSet<TblFoodOrder> FoodOrders { get; set; } = null!;
        public DbSet<TblTransactionSequence> TransactionSequences { get; set; } = null!;
        public DbSet<TblState> States { get; set; } = null!;
        public DbSet<TblCity> Cities { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    // STRING CONVENTIONS
                    if (property.ClrType == typeof(string))
                    {
                        if (property.GetMaxLength() != null)
                            continue;

                        var name = property.Name.ToLower();

                        if (name.Contains("city") || name.Contains("state") || name.Contains("country"))
                            property.SetMaxLength(20);
                        else if (name.Contains("number"))
                            property.SetMaxLength(50);
                        else if (name.Contains("name"))
                            property.SetMaxLength(50);
                        else if (name.Contains("description") || name.Contains("note"))
                            property.SetMaxLength(255);
                        else if (name.Contains("code"))
                            property.SetMaxLength(10);
                        else if (name.Contains("gender"))
                            property.SetMaxLength(15);
                        else if (name.Contains("url"))
                            property.SetMaxLength(400);
                        else
                            property.SetMaxLength(150);
                    }

                    // DECIMAL CONVENTIONS
                    else if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                    {
                        // Skip if precision already set
                        if (property.GetPrecision() != null)
                            continue;

                        property.SetDefaultValue(0M);
                        property.SetPrecision(12);
                        property.SetScale(2);
                    }
                    else if (property.ClrType == typeof(bool) || property.ClrType == typeof(bool?))
                    {
                        // Skip if default already set
                        if (property.GetDefaultValue() != null)
                            continue;

                        property.SetDefaultValue(false);
                    }
                }
            }

            modelBuilder.Entity<TblAddress>(e =>
            {
                //e.ToTable("tblAddress");
                //e.HasKey(p => p.ID);
                //e.Property(p => p.ID).ValueGeneratedOnAdd();
                e.Property(p => p.AddressLine1).HasMaxLength(100);
                e.Property(p => p.AddressLine2).HasMaxLength(100);
                e.Property(p => p.City).HasMaxLength(50);
                e.Property(p => p.State).HasMaxLength(50);
                e.Property(p => p.Country).HasMaxLength(100);
                e.Property(p => p.ZipCode).HasMaxLength(20);
                e.Property(p => p.TableName).HasMaxLength(20);

                e.HasOne(p => p.Hotel).WithMany().HasForeignKey(t => t.HotelID);
                e.HasOne(p => p.Guest).WithMany().HasForeignKey(t => t.GuestID); ;
            });

            modelBuilder.Entity<TblHotel>(e =>
            {
                //e.ToTable("tblHotel");
                //e.HasKey(p => p.ID);
                //e.Property(p => p.ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TblRoom>(e =>
            {
                e.HasOne(r => r.Hotel)
                 .WithMany(h => h.Rooms)
                 .HasForeignKey(r => r.HotelID)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TblGuest>(e =>
            {
                e.HasOne(r => r.Hotel)
                 .WithMany(h => h.Guests)
                 .HasForeignKey(r => r.HotelID)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TblIdentityProof>(e =>
            {
                e.HasOne(ip => ip.Guest)
                 .WithMany(g => g.IdentityProof)
                 .HasForeignKey(ip => ip.GuestID)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TblUser>(e =>
            {
                e.HasOne(u => u.Hotel)
                 .WithMany(h => h.Users)
                 .HasForeignKey(t => t.HotelID)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TblAminities>(e =>
            {
                e.HasOne(a => a.Hotel)
                 .WithMany()
                 .HasForeignKey(a => a.HotelID)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(a => a.Room)
                 .WithMany(r => r.Aminities)
                 .HasForeignKey(a => a.RoomID)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TblCleaning>(e =>
            {
                e.Property(p => p.Cost).HasPrecision(10, 2);

                e.HasOne(c => c.Room)
                 .WithMany()
                 .HasForeignKey(c => c.RoomID)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(c => c.Cleaner)
                 .WithMany()
                 .HasForeignKey(c => c.CleanerID)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(c => c.Inspector)
                 .WithMany()
                 .HasForeignKey(c => c.InspectorID)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TblBookingMaster>(e =>
            {
                e.HasOne(b => b.Guest)
                 .WithMany(bm => bm.BookingMasters)
                 .HasForeignKey(b => b.GuestID)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(b => b.Hotel)
                 .WithMany()
                 .HasForeignKey(b => b.HotelID)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TblBookingMaster>()
                .ToTable(tb => tb.HasTrigger("trg_BookingMasters_Audit"));

            modelBuilder.Entity<TblRoomBooking>(e =>
            {
                e.HasOne(rb => rb.Room)
                 .WithMany(r => r.RoomBookings)
                 .HasForeignKey(rb => rb.RoomID)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(rb => rb.Hotel)
                 .WithMany()
                 .HasForeignKey(rb => rb.HotelID)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(rb => rb.Guest)
                 .WithMany()
                 .HasForeignKey(rb => rb.GuestID)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(rb => rb.BookingMaster)
                 .WithMany(bm => bm.RoomBookings)
                 .HasForeignKey(rb => rb.BookingMasterID)
                 .OnDelete(DeleteBehavior.Restrict);

                e.ToTable(tb => tb.HasTrigger("Tr_Update_Delete_Bookings"));

            });

            modelBuilder.Entity<TblPayment>(e =>
            {
                e.HasOne(rb => rb.Hotel)
                 .WithMany()
                 .HasForeignKey("HotelID")
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(pmt => pmt.BookingMaster)
                 .WithMany(bm => bm.Payments)
                 .HasForeignKey(pmt => pmt.BookingMasterID)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(rb => rb.Room)
                .WithMany(bm => bm.Payments)
                .HasForeignKey(rb => rb.RoomID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TblPayment>()
               .ToTable(tb => tb.HasTrigger("trg_Payments_Audit"));

            modelBuilder.Entity<TblFoodMenu>(e =>
            {
                e.HasKey(p => p.ID);
                e.Property(p => p.ID).ValueGeneratedOnAdd();
                e.Property(p => p.Price).HasPrecision(12, 2);

                e.HasOne(fm => fm.Hotel)
                 .WithMany()
                 .HasForeignKey("HotelID")
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TblFoodOrder>(e =>
            {
                e.HasOne(fm => fm.Hotel)
                  .WithMany()
                  .HasForeignKey("HotelID")
                  .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(fm => fm.Room)
                 .WithMany()
                 .HasForeignKey("RoomID")
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(fm => fm.Guest)
                 .WithMany()
                 .HasForeignKey("GuestID")
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TblUserRole>()
                   .HasKey(mr => new { mr.UserID, mr.RoleID });

            modelBuilder.Entity<TblTransactionSequence>()
                   .HasKey(ts => new { ts.HotelID, ts.TransactionTypeId });

            modelBuilder.Entity<TblState>(e =>
            {
                e.ToTable("States");

                e.HasKey(s => s.StateID);

                e.Property(s => s.StateCode)
                 .IsRequired()
                 .HasMaxLength(10);

                e.Property(s => s.StateName)
                 .IsRequired()
                 .HasMaxLength(100);

                e.HasIndex(s => s.StateCode)
                 .IsUnique();

                e.HasIndex(s => s.StateName)
                 .IsUnique();
            });

            modelBuilder.Entity<TblCity>(e =>
            {
                e.ToTable("Cities");

                e.HasKey(c => c.CityID);

                e.Property(c => c.CityName)
                 .IsRequired()
                 .HasMaxLength(100);

                e.HasOne(c => c.State)
                 .WithMany(s => s.Cities)
                 .HasForeignKey(c => c.StateID)
                 .OnDelete(DeleteBehavior.Restrict);

                // UNIQUE (CityName + StateID)
                e.HasIndex(c => new { c.CityName, c.StateID })
                 .IsUnique();
            });

            modelBuilder.SeedStatesAndCities();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
