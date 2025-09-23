using System;
using System.Collections.Generic;
using AVi.Models;
using Microsoft.EntityFrameworkCore;

namespace AVi.Context;

public partial class User020Context : DbContext
{
    public User020Context()
    {
    }

    public User020Context(DbContextOptions<User020Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Aircraft> Aircrafts { get; set; }

    public virtual DbSet<AircraftsModel> AircraftsModels { get; set; }

    public virtual DbSet<Airline> Airlines { get; set; }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<Booker> Bookers { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<PlaneClass> PlaneClasses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tarif> Tarifs { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.111.169.167;Database=user020;Username=user020;password=User.020");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aircraft>(entity =>
        {
            entity.HasKey(e => e.AircraftsId).HasName("aircrafts_pkey");

            entity.ToTable("aircrafts");

            entity.Property(e => e.AircraftsId).HasColumnName("aircrafts_id");
            entity.Property(e => e.AircraftsModel).HasColumnName("aircrafts_model");
            entity.Property(e => e.AircraftsName)
                .HasColumnType("character varying")
                .HasColumnName("aircrafts_name");

            entity.HasOne(d => d.AircraftsModelNavigation).WithMany(p => p.Aircraft)
                .HasForeignKey(d => d.AircraftsModel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_model");
        });

        modelBuilder.Entity<AircraftsModel>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("aircrafts_models_pkey");

            entity.ToTable("aircrafts_models");

            entity.Property(e => e.ModelId)
                .ValueGeneratedNever()
                .HasColumnName("model_id");
            entity.Property(e => e.ModelName)
                .HasColumnType("character varying")
                .HasColumnName("model_name");
        });

        modelBuilder.Entity<Airline>(entity =>
        {
            entity.HasKey(e => e.AirlinesId).HasName("airlines_pkey");

            entity.ToTable("airlines");

            entity.Property(e => e.AirlinesId)
                .ValueGeneratedNever()
                .HasColumnName("airlines_id");
            entity.Property(e => e.AirlinesName)
                .HasColumnType("character varying")
                .HasColumnName("airlines_name");
        });

        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.AirportId).HasName("airport_pkey");

            entity.ToTable("airport");

            entity.Property(e => e.AirportId).HasColumnName("airport_id");
            entity.Property(e => e.AirportCity).HasColumnName("airport_city");
            entity.Property(e => e.AirportName)
                .HasColumnType("character varying")
                .HasColumnName("airport_name");

            entity.HasOne(d => d.AirportCityNavigation).WithMany(p => p.Airports)
                .HasForeignKey(d => d.AirportCity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_city");
        });

        modelBuilder.Entity<Booker>(entity =>
        {
            entity.HasKey(e => e.BookerId).HasName("bookers_pkey");

            entity.ToTable("bookers");

            entity.Property(e => e.BookerId).HasColumnName("booker_id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Bookers)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ticket");

            entity.HasOne(d => d.User).WithMany(p => p.BookersNavigation)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("cities_pkey");

            entity.ToTable("cities");

            entity.Property(e => e.CityId)
                .ValueGeneratedNever()
                .HasColumnName("city_id");
            entity.Property(e => e.CityName)
                .HasColumnType("character varying")
                .HasColumnName("city_name");
            entity.Property(e => e.CountryId).HasColumnName("country_id");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_country");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("country_pkey");

            entity.ToTable("country");

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasColumnName("country_id");
            entity.Property(e => e.CountryName)
                .HasColumnType("character varying")
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<PlaneClass>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("plane_class_pkey");

            entity.ToTable("plane_class");

            entity.Property(e => e.ClassId)
                .ValueGeneratedNever()
                .HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasColumnType("character varying")
                .HasColumnName("class_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasColumnType("character varying")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Tarif>(entity =>
        {
            entity.HasKey(e => e.TarifId).HasName("tarif_pkey");

            entity.ToTable("tarif");

            entity.Property(e => e.TarifId)
                .ValueGeneratedNever()
                .HasColumnName("tarif_id");
            entity.Property(e => e.BackupState)
                .HasDefaultValue(false)
                .HasColumnName("backup_state");
            entity.Property(e => e.BaggageCount)
                .HasDefaultValue(0)
                .HasColumnName("baggage_count");
            entity.Property(e => e.BaggageState)
                .HasDefaultValue(false)
                .HasColumnName("baggage_state");
            entity.Property(e => e.SwitchState)
                .HasDefaultValue(false)
                .HasColumnName("switch_state");
            entity.Property(e => e.TarifCost).HasColumnName("tarif_cost");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("tickets_pkey");

            entity.ToTable("tickets");

            entity.HasIndex(e => e.TicketNumb, "un_numb").IsUnique();

            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.AircraftId).HasColumnName("aircraft_id");
            entity.Property(e => e.AirlinesId).HasColumnName("airlines_id");
            entity.Property(e => e.ArAirportId).HasColumnName("ar_airport_id");
            entity.Property(e => e.BookerState)
                .HasDefaultValue(false)
                .HasColumnName("booker_state");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.DepAirportId).HasColumnName("dep_airport_id");
            entity.Property(e => e.Seat)
                .HasColumnType("character varying")
                .HasColumnName("seat");
            entity.Property(e => e.TarifId).HasColumnName("tarif_id");
            entity.Property(e => e.TicketNumb).HasColumnName("ticket_numb");
            entity.Property(e => e.TimeIn)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time_in");
            entity.Property(e => e.TimeOut)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time_out");

            entity.HasOne(d => d.Aircraft).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.AircraftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_aircraft");

            entity.HasOne(d => d.Airlines).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.AirlinesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_airlines");

            entity.HasOne(d => d.ArAirport).WithMany(p => p.TicketArAirports)
                .HasForeignKey(d => d.ArAirportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ar_airport");

            entity.HasOne(d => d.Class).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_class");

            entity.HasOne(d => d.DepAirport).WithMany(p => p.TicketDepAirports)
                .HasForeignKey(d => d.DepAirportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dep_airport");

            entity.HasOne(d => d.Tarif).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TarifId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tarif");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Bookers).HasColumnName("bookers");
            entity.Property(e => e.Passwordhash)
                .HasColumnType("character varying")
                .HasColumnName("passwordhash");
            entity.Property(e => e.Salt)
                .HasColumnType("character varying")
                .HasColumnName("salt");
            entity.Property(e => e.UserEmail)
                .HasColumnType("character varying")
                .HasColumnName("user_email");
            entity.Property(e => e.UserFio)
                .HasColumnType("character varying")
                .HasColumnName("user_fio");
            entity.Property(e => e.UserPasport)
                .HasColumnType("character varying")
                .HasColumnName("user_pasport");
            entity.Property(e => e.UserPhone)
                .HasColumnType("character varying")
                .HasColumnName("user_phone");
            entity.Property(e => e.UserRole).HasColumnName("user_role");

            entity.HasOne(d => d.Bookers1).WithMany(p => p.Users)
                .HasForeignKey(d => d.Bookers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bookers");

            entity.HasOne(d => d.UserRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
