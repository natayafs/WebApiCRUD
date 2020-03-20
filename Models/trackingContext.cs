using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiCRUD.Models
{
    public partial class trackingContext : DbContext
    {
        public trackingContext()
        {
        }

        public trackingContext(DbContextOptions<trackingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Alert> Alert { get; set; }
        public virtual DbSet<AlertGeofence> AlertGeofence { get; set; }
        public virtual DbSet<AlertVehicle> AlertVehicle { get; set; }
        public virtual DbSet<Alertnotification> Alertnotification { get; set; }
        public virtual DbSet<Competitor> Competitor { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Enterprise> Enterprise { get; set; }
        public virtual DbSet<Geofence> Geofence { get; set; }
        public virtual DbSet<Geofencetype> Geofencetype { get; set; }
        public virtual DbSet<Gpsreporthistory> Gpsreporthistory { get; set; }
        public virtual DbSet<Lastgpsreport> Lastgpsreport { get; set; }
        public virtual DbSet<Marathon> Marathon { get; set; }
        public virtual DbSet<Parade> Parade { get; set; }
        public virtual DbSet<ReporteRegistrosVencidos> ReporteRegistrosVencidos { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<TimeMark> TimeMark { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<Vehiclebrand> Vehiclebrand { get; set; }
        public virtual DbSet<VehiclebrandBackup> VehiclebrandBackup { get; set; }
        public virtual DbSet<Vehiclegroup> Vehiclegroup { get; set; }
        public virtual DbSet<Vehiclemodel> Vehiclemodel { get; set; }
        public virtual DbSet<Vehicletype> Vehicletype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=104.217.253.86;initial catalog=tracking;user id=alumno;password=12345678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Addressline1)
                    .HasColumnName("addressline1")
                    .HasMaxLength(255);

                entity.Property(e => e.Addressline2)
                    .HasColumnName("addressline2")
                    .HasMaxLength(255);

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Townorcity)
                    .HasColumnName("townorcity")
                    .HasMaxLength(255);

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.State)
                    .HasConstraintName("FK_address_state");
            });

            modelBuilder.Entity<Alert>(entity =>
            {
                entity.ToTable("alert");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Enterpriseid).HasColumnName("enterpriseid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Notifywhenarriving).HasColumnName("notifywhenarriving");

                entity.Property(e => e.Notifywhenleaving).HasColumnName("notifywhenleaving");
            });

            modelBuilder.Entity<AlertGeofence>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("alert_geofence");

                entity.Property(e => e.Grofenceid).HasColumnName("grofenceid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ordering).HasColumnName("ordering");
            });

            modelBuilder.Entity<AlertVehicle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("alert_vehicle");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.Vehicleid).HasColumnName("vehicleid");
            });

            modelBuilder.Entity<Alertnotification>(entity =>
            {
                entity.ToTable("alertnotification");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alertid).HasColumnName("alertid");

                entity.Property(e => e.Alerttype).HasColumnName("alerttype");

                entity.Property(e => e.Dismissed)
                    .HasColumnName("dismissed")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Geofenceid).HasColumnName("geofenceid");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");

                entity.Property(e => e.Vehicleid).HasColumnName("vehicleid");

                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.Alertnotification)
                    .HasForeignKey(d => d.Alertid)
                    .HasConstraintName("FK_alertnotification_alert");

                entity.HasOne(d => d.Geofence)
                    .WithMany(p => p.Alertnotification)
                    .HasForeignKey(d => d.Geofenceid)
                    .HasConstraintName("FK_alertnotification_geofence");
            });

            modelBuilder.Entity<Competitor>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("pk_competitor")
                    .IsClustered(false);

                entity.ToTable("competitor");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .ValueGeneratedNever();

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasColumnName("latitude")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasColumnName("longitude")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Competitor)
                    .HasForeignKey<Competitor>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_competit_competiro_user");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("driver");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Addressid).HasColumnName("addressid");

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(255);

                entity.Property(e => e.Driverlicense)
                    .HasColumnName("driverlicense")
                    .HasMaxLength(255);

                entity.Property(e => e.Driverlicenseexpirationdate).HasColumnName("driverlicenseexpirationdate");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Enterpriseid).HasColumnName("enterpriseid");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(255);

                entity.Property(e => e.Idnumber)
                    .HasColumnName("idnumber")
                    .HasMaxLength(255);

                entity.Property(e => e.Imageurl)
                    .HasColumnName("imageurl")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.Addressid)
                    .HasConstraintName("FK_driver_address");
            });

            modelBuilder.Entity<Enterprise>(entity =>
            {
                entity.ToTable("enterprise");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Reseller).HasColumnName("reseller");

                entity.HasOne(d => d.AddressNavigation)
                    .WithMany(p => p.Enterprise)
                    .HasForeignKey(d => d.Address)
                    .HasConstraintName("FK_enterprise_address");
            });

            modelBuilder.Entity<Geofence>(entity =>
            {
                entity.ToTable("geofence");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.Enterpriseid).HasColumnName("enterpriseid");

                entity.Property(e => e.Geofencetypeid).HasColumnName("geofencetypeid");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Radius).HasColumnName("radius");

                entity.HasOne(d => d.Enterprise)
                    .WithMany(p => p.Geofence)
                    .HasForeignKey(d => d.Enterpriseid)
                    .HasConstraintName("FK_geofence_enterprise1");

                entity.HasOne(d => d.Geofencetype)
                    .WithMany(p => p.Geofence)
                    .HasForeignKey(d => d.Geofencetypeid)
                    .HasConstraintName("FK_geofence_geofencetype");
            });

            modelBuilder.Entity<Geofencetype>(entity =>
            {
                entity.ToTable("geofencetype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Colour)
                    .HasColumnName("colour")
                    .HasMaxLength(255);

                entity.Property(e => e.Enterpriseid).HasColumnName("enterpriseid");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Gpsreporthistory>(entity =>
            {
                entity.ToTable("gpsreporthistory");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");

                entity.Property(e => e.Vehicleid).HasColumnName("vehicleid");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Gpsreporthistory)
                    .HasForeignKey(d => d.Vehicleid)
                    .HasConstraintName("FK_gpsreporthistory_vehicle");
            });

            modelBuilder.Entity<Lastgpsreport>(entity =>
            {
                entity.ToTable("lastgpsreport");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");

                entity.Property(e => e.Vehicleid).HasColumnName("vehicleid");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Lastgpsreport)
                    .HasForeignKey(d => d.Vehicleid)
                    .HasConstraintName("FK_lastgpsreport_vehicle");
            });

            modelBuilder.Entity<Marathon>(entity =>
            {
                entity.HasKey(e => e.IdMarathon)
                    .HasName("pk_marathon")
                    .IsClustered(false);

                entity.ToTable("marathon");

                entity.Property(e => e.IdMarathon).HasColumnName("id_marathon");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.CompetitorsLimit).HasColumnName("competitors_limit");

                entity.Property(e => e.Detail)
                    .HasColumnName("detail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FinalLatitude)
                    .IsRequired()
                    .HasColumnName("final_latitude")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FinalLongitude)
                    .IsRequired()
                    .HasColumnName("final_longitude")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InitialLatitude)
                    .IsRequired()
                    .HasColumnName("initial_latitude")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InitialLongitude)
                    .IsRequired()
                    .HasColumnName("initial_longitude")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JsonUploaded).HasColumnName("json_uploaded");

                entity.Property(e => e.RaceStartDate)
                    .HasColumnName("race_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RegistrationDeadline)
                    .HasColumnName("registration_deadline")
                    .HasColumnType("datetime");

                entity.Property(e => e.RegistrationStartDate)
                    .HasColumnName("registration_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parade>(entity =>
            {
                entity.HasKey(e => e.IdParade)
                    .HasName("pk_parade")
                    .IsClustered(false);

                entity.ToTable("parade");

                entity.HasIndex(e => e.IdMarathon)
                    .HasName("relationship_6_fk");

                entity.Property(e => e.IdParade).HasColumnName("id_parade");

                entity.Property(e => e.IdMarathon).HasColumnName("id_marathon");

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasColumnName("latitude")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasColumnName("longitude")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ordernumber).HasColumnName("ordernumber");

                entity.HasOne(d => d.IdMarathonNavigation)
                    .WithMany(p => p.Parade)
                    .HasForeignKey(d => d.IdMarathon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_parade_relations_marathon");
            });

            modelBuilder.Entity<ReporteRegistrosVencidos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ReporteRegistrosVencidos");

                entity.Property(e => e.Reporte)
                    .IsRequired()
                    .HasColumnName("reporte")
                    .HasMaxLength(581);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdMarathon })
                    .HasName("pk_result")
                    .IsClustered(false);

                entity.ToTable("result");

                entity.HasIndex(e => e.IdMarathon)
                    .HasName("relationship_4_fk");

                entity.HasIndex(e => e.IdUser)
                    .HasName("relationship_3_fk");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IdMarathon).HasColumnName("id_marathon");

                entity.Property(e => e.ArrivalTime)
                    .HasColumnName("arrival_time_")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdMarathonNavigation)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.IdMarathon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_result_marathon__marathon");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_result_competito_competit");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK_state_country");
            });

            modelBuilder.Entity<TimeMark>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdParade })
                    .HasName("pk_time_mark")
                    .IsClustered(false);

                entity.ToTable("time_mark");

                entity.HasIndex(e => e.IdParade)
                    .HasName("relationship_7_fk");

                entity.HasIndex(e => e.IdUser)
                    .HasName("relationship_8_fk");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IdParade).HasColumnName("id_parade");

                entity.Property(e => e.ArrivalTime)
                    .HasColumnName("arrival_time_")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdParadeNavigation)
                    .WithMany(p => p.TimeMark)
                    .HasForeignKey(d => d.IdParade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_time_mar_time_mark_parade");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.TimeMark)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_time_mar_competito_competit");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("pk_user")
                    .IsClustered(false);

                entity.ToTable("user");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

                entity.Property(e => e.BodyHeight)
                    .HasColumnName("body_height")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BodyWeight)
                    .HasColumnName("body_weight")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Dni)
                    .HasColumnName("dni")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MedicaCertificate).HasColumnName("medica_certificate");

                entity.Property(e => e.Nick)
                    .IsRequired()
                    .HasColumnName("nick")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterDate)
                    .HasColumnName("register_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Talle)
                    .HasColumnName("talle")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicle");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Driverid).HasColumnName("driverid");

                entity.Property(e => e.Enterpriseid).HasColumnName("enterpriseid");

                entity.Property(e => e.Gps)
                    .HasColumnName("gps")
                    .HasMaxLength(255);

                entity.Property(e => e.Isinuse)
                    .HasColumnName("isinuse")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Licenseplate)
                    .HasColumnName("licenseplate")
                    .HasMaxLength(255);

                entity.Property(e => e.Motornumber)
                    .HasColumnName("motornumber")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Seriesnumber)
                    .HasColumnName("seriesnumber")
                    .HasMaxLength(255);

                entity.Property(e => e.Vehiclegroupid).HasColumnName("vehiclegroupid");

                entity.Property(e => e.Vehiclemodelid).HasColumnName("vehiclemodelid");

                entity.Property(e => e.Vehicletypeid).HasColumnName("vehicletypeid");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.Driverid)
                    .HasConstraintName("FK_vehicle_driver");

                entity.HasOne(d => d.Vehiclegroup)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.Vehiclegroupid)
                    .HasConstraintName("FK_vehicle_vehiclegroup");

                entity.HasOne(d => d.Vehiclemodel)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.Vehiclemodelid)
                    .HasConstraintName("FK_vehicle_vehiclemodel");

                entity.HasOne(d => d.Vehicletype)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.Vehicletypeid)
                    .HasConstraintName("FK_vehicle_vehicletype");
            });

            modelBuilder.Entity<Vehiclebrand>(entity =>
            {
                entity.ToTable("vehiclebrand");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Enterpriseid).HasColumnName("enterpriseid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<VehiclebrandBackup>(entity =>
            {
                entity.ToTable("vehiclebrand_backup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Enterpriseid).HasColumnName("enterpriseid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Enterprise)
                    .WithMany(p => p.VehiclebrandBackup)
                    .HasForeignKey(d => d.Enterpriseid)
                    .HasConstraintName("fk_enterprise_vehiclebrand");
            });

            modelBuilder.Entity<Vehiclegroup>(entity =>
            {
                entity.ToTable("vehiclegroup");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Colour)
                    .HasColumnName("colour")
                    .HasMaxLength(255);

                entity.Property(e => e.Colourname)
                    .HasColumnName("colourname")
                    .HasMaxLength(255);

                entity.Property(e => e.Enterpriseid).HasColumnName("enterpriseid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Vehiclemodel>(entity =>
            {
                entity.ToTable("vehiclemodel");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(255);

                entity.Property(e => e.Vehiclebrandid).HasColumnName("vehiclebrandid");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Vehiclebrand)
                    .WithMany(p => p.Vehiclemodel)
                    .HasForeignKey(d => d.Vehiclebrandid)
                    .HasConstraintName("FK_vehiclemodel_vehiclebrand");
            });

            modelBuilder.Entity<Vehicletype>(entity =>
            {
                entity.ToTable("vehicletype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Enterpriseid).HasColumnName("enterpriseid");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(255);

                entity.Property(e => e.Maxspeed).HasColumnName("maxspeed");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
