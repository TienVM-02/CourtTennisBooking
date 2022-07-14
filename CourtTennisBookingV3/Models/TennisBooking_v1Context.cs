using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CourtTennisBookingV3.Models
{
    public partial class TennisBooking_v1Context : DbContext
    {
        public TennisBooking_v1Context()
        {
        }

        public TennisBooking_v1Context(DbContextOptions<TennisBooking_v1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<CourtOwner> CourtOwners { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<TennisCourt> TennisCourts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MINHLUAN\\SQLEXPRESS;Initial Catalog=TennisBooking_v1;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accounts_Roles");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);


                entity.Property(e => e.BookingDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(20)
                    .IsUnicode(false);

             

                entity.Property(e => e.CourtId)
                    .HasMaxLength(20)
                    .IsUnicode(false);



                entity.Property(e => e.CusId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CusName).HasMaxLength(100);

                entity.Property(e => e.TimeEnd)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStart)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Court)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CourtId)
                    .HasConstraintName("FK_Booking_TennisCourt1");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("FK_Booking_Customers");
            });

            modelBuilder.Entity<CourtOwner>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK_CourtOwners");

                entity.ToTable("CourtOwner");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK_Customers");

                entity.ToTable("Customer");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TennisCourt>(entity =>
            {
                entity.ToTable("TennisCourt");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Group)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.OwnerId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.TennisCourts)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_TennisCourt_CourtOwners");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
