using System;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HARMIC.Models
{
    public partial class Travel_BookerContext : DbContext
    {
        public Travel_BookerContext()
        {
        }

        public Travel_BookerContext(DbContextOptions<Travel_BookerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accomodation> Accomodations { get; set; }
        public virtual DbSet<AccomodationDetail> AccomodationDetails { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<BookingStatus> BookingStatuses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Utility> Utilities { get; set; }
        public IEnumerable Countries { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SYNPHONIA\\SQLEXPRESS; Database =Travel_Booker;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Accomodation>(entity =>
            {
                entity.ToTable("Accomodation");

                entity.Property(e => e.AccomodationId).HasColumnName("accomodationID");

                entity.Property(e => e.AccomodationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("accomodationName")
                    .IsFixedLength(true);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city")
                    .IsFixedLength(true);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("country")
                    .IsFixedLength(true);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .HasColumnName("image");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber")
                    .IsFixedLength(true);

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.Utilities).HasColumnName("utilities");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Accomodations)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accomodation_Category");
            });

            modelBuilder.Entity<AccomodationDetail>(entity =>
            {
                entity.HasKey(e => new { e.DetailId, e.RoomName })
                    .HasName("PK_Accomodation_Details");

                entity.Property(e => e.DetailId).HasColumnName("detailID");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(200)
                    .HasColumnName("roomName")
                    .IsFixedLength(true);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.RoomCapacity).HasColumnName("roomCapacity");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(10)
                    .HasColumnName("roomNumber")
                    .IsFixedLength(true);

                entity.Property(e => e.RoomPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("roomPrice");

                entity.Property(e => e.RoomStatus)
                    .HasMaxLength(20)
                    .HasColumnName("roomStatus")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Detail)
                    .WithMany(p => p.AccomodationDetails)
                    .HasForeignKey(d => d.DetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccomodationDetails_Accomodation");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(150);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Salt)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Accounts_Roles");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bookingID")
                    .IsFixedLength(true);

                entity.Property(e => e.BookingDetailId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bookingDetailID")
                    .IsFixedLength(true);

                entity.Property(e => e.BookingStatusId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bookingStatusID")
                    .IsFixedLength(true);

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.HasOne(d => d.BookingDetail)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BookingDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_BookingDetails");

                entity.HasOne(d => d.BookingStatus)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BookingStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_BookingStatus");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Category");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Accounts");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.Property(e => e.BookingDetailId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bookingDetailID")
                    .IsFixedLength(true);

                entity.Property(e => e.ArrivalDate)
                    .HasColumnType("date")
                    .HasColumnName("arrivalDate");

                entity.Property(e => e.AssignRoomId)
                    .HasMaxLength(50)
                    .HasColumnName("assignRoomID")
                    .IsFixedLength(true);

                entity.Property(e => e.BookingDate)
                    .HasColumnType("date")
                    .HasColumnName("bookingDate");

                entity.Property(e => e.DepartureDate)
                    .HasColumnType("date")
                    .HasColumnName("departureDate");

                entity.Property(e => e.NumberPeople).HasColumnName("numberPeople");

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(10)
                    .HasColumnName("paymentID")
                    .IsFixedLength(true);

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("totalAmount");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_BookingDetails_BookingDetails");
            });

            modelBuilder.Entity<BookingStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK_Booking Status");

                entity.ToTable("BookingStatus");

                entity.Property(e => e.StatusId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("statusID")
                    .IsFixedLength(true);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("categoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("categoryName")
                    .IsFixedLength(true);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customerID")
                    .IsFixedLength(true);

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("date")
                    .HasColumnName("dateofbirth");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("gender")
                    .IsFixedLength(true);

                entity.Property(e => e.IdNumber).HasColumnName("idNumber");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("lastname")
                    .IsFixedLength(true);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50)
                    .HasColumnName("nationality")
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber")
                    .IsFixedLength(true);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("surname")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(10)
                    .HasColumnName("paymentID")
                    .IsFixedLength(true);

                entity.Property(e => e.BookingId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bookingID")
                    .IsFixedLength(true);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.PaymentStatusId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("paymentStatusID")
                    .IsFixedLength(true);

                entity.Property(e => e.PaymentTypeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("paymentTypeID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Booking");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_PaymentStatus");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_PaymentType");
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.ToTable("PaymentStatus");

                entity.Property(e => e.PaymentStatusId)
                    .HasMaxLength(10)
                    .HasColumnName("paymentStatusID")
                    .IsFixedLength(true);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PaymentType");

                entity.Property(e => e.PaymentTypeId)
                    .HasMaxLength(10)
                    .HasColumnName("paymentTypeID")
                    .IsFixedLength(true);

                entity.Property(e => e.PaymentType1)
                    .HasMaxLength(10)
                    .HasColumnName("paymentType")
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("userID")
                    .IsFixedLength(true);

                entity.Property(e => e.LoginDate)
                    .HasColumnType("date")
                    .HasColumnName("loginDate");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password")
                    .IsFixedLength(true);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName")
                    .IsFixedLength(true);

                entity.HasOne(d => d.UserNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Customer");
            });

            modelBuilder.Entity<Utility>(entity =>
            {
                entity.Property(e => e.UtilityId).HasColumnName("utilityID");

                entity.Property(e => e.UtilityName)
                    .HasMaxLength(50)
                    .HasColumnName("utilityName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
