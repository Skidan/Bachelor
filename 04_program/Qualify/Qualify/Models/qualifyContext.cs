using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Qualify.Models
{
    public partial class qualifyContext : DbContext
    {
        public qualifyContext()
        {
        }

        public qualifyContext(DbContextOptions<qualifyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<Certificate> Certificate { get; set; }
        public virtual DbSet<Claim> Claim { get; set; }
        public virtual DbSet<ClaimComments> ClaimComments { get; set; }
        public virtual DbSet<ClaimExpences> ClaimExpences { get; set; }
        public virtual DbSet<ClaimHistory> ClaimHistory { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<CompetentionMatrix> CompetentionMatrix { get; set; }
        public virtual DbSet<CompetentionPattern> CompetentionPattern { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderType> OrderType { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<QualityCard> QualityCard { get; set; }
        public virtual DbSet<ToolList> ToolList { get; set; }
        public virtual DbSet<ToolProp> ToolProp { get; set; }
        public virtual DbSet<ToolType> ToolType { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<WhItems> WhItems { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=qualify;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("ACTION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aim)
                    .IsRequired()
                    .HasColumnName("AIM")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.DateEnd)
                    .HasColumnName("DATE_END")
                    .HasColumnType("date");

                entity.Property(e => e.DateStart)
                    .HasColumnName("DATE_START")
                    .HasColumnType("date");

                entity.Property(e => e.WorkerId).HasColumnName("WORKER_ID");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Action)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ACTION_WORKER1");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("CERTIFICATE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CertId)
                    .HasColumnName("CERT_ID")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.DateFrom)
                    .HasColumnName("DATE_FROM")
                    .HasColumnType("date");

                entity.Property(e => e.DateTill)
                    .HasColumnName("DATE_TILL")
                    .HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.Link)
                    .HasColumnName("LINK")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ReminderMonth)
                    .HasColumnName("REMINDER_MONTH")
                    .HasDefaultValueSql("((3))");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Certificate)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CERTIFICATE_EMPLOYEE1");
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.ToTable("CLAIM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.DateEnd)
                    .HasColumnName("DATE_END")
                    .HasColumnType("date");

                entity.Property(e => e.DateStart)
                    .HasColumnName("DATE_START")
                    .HasColumnType("date");

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Claim)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CLAIM_CLIENT1");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Claim)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CLAIM_ORDER1");
            });

            modelBuilder.Entity<ClaimComments>(entity =>
            {
                entity.ToTable("CLAIM_COMMENTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActionId).HasColumnName("ACTION_ID");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("COMMENT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp)
                    .HasColumnName("TIMESTAMP")
                    .HasColumnType("datetime2(0)");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ClaimComments)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CLAIM_COMMENTS_ACTION1");
            });

            modelBuilder.Entity<ClaimExpences>(entity =>
            {
                entity.ToTable("CLAIM_EXPENCES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClaimId).HasColumnName("CLAIM_ID");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("COMMENT")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("date");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Link)
                    .HasColumnName("LINK")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Sum).HasColumnName("SUM");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.ClaimExpences)
                    .HasForeignKey(d => d.ClaimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CLAIM_EXPENCES_CLAIM1");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.ClaimExpences)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CLAIM_EXPENCES_DEPARTMENT1");
            });

            modelBuilder.Entity<ClaimHistory>(entity =>
            {
                entity.ToTable("CLAIM_HISTORY");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActionId).HasColumnName("ACTION_ID");

                entity.Property(e => e.ClaimId).HasColumnName("CLAIM_ID");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ClaimHistory)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CLAIM_HISTORY_ACTION1");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.ClaimHistory)
                    .HasForeignKey(d => d.ClaimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CLAIM_HISTORY_CLAIM1");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("CLIENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnName("CONTACT")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasColumnName("COUNTRY_ID");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CLIENT_COUNTRY1");
            });

            modelBuilder.Entity<CompetentionMatrix>(entity =>
            {
                entity.ToTable("COMPETENTION_MATRIX");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Accounting).HasColumnName("ACCOUNTING");

                entity.Property(e => e.Brakes).HasColumnName("BRAKES");

                entity.Property(e => e.Chemistry).HasColumnName("CHEMISTRY");

                entity.Property(e => e.Constructing).HasColumnName("CONSTRUCTING");

                entity.Property(e => e.Drawing).HasColumnName("DRAWING");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.Forklift).HasColumnName("FORKLIFT");

                entity.Property(e => e.Languages).HasColumnName("LANGUAGES");

                entity.Property(e => e.Management).HasColumnName("MANAGEMENT");

                entity.Property(e => e.Quality).HasColumnName("QUALITY");

                entity.Property(e => e.Welding).HasColumnName("WELDING");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CompetentionMatrix)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_COMPETENTION_MATRIX_EMPLOYEE1");
            });

            modelBuilder.Entity<CompetentionPattern>(entity =>
            {
                entity.ToTable("COMPETENTION_PATTERN");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Accounting).HasColumnName("ACCOUNTING");

                entity.Property(e => e.Brakes).HasColumnName("BRAKES");

                entity.Property(e => e.Chemistry).HasColumnName("CHEMISTRY");

                entity.Property(e => e.Constructing).HasColumnName("CONSTRUCTING");

                entity.Property(e => e.Drawings).HasColumnName("DRAWINGS");

                entity.Property(e => e.Forklift).HasColumnName("FORKLIFT");

                entity.Property(e => e.Languages).HasColumnName("LANGUAGES");

                entity.Property(e => e.Management).HasColumnName("MANAGEMENT");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Quality).HasColumnName("QUALITY");

                entity.Property(e => e.Welding).HasColumnName("WELDING");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("COUNTRY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Locale)
                    .IsRequired()
                    .HasColumnName("LOCALE")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Tradezone)
                    .HasColumnName("TRADEZONE")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CdeptCompetentionPattern).HasColumnName("CDEPT_COMPETENTION_PATTERN");

                entity.Property(e => e.DeptAccounts).HasColumnName("DEPT_ACCOUNTS");

                entity.Property(e => e.DeptCode)
                    .IsRequired()
                    .HasColumnName("DEPT_CODE")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DeptHead).HasColumnName("DEPT_HEAD");

                entity.Property(e => e.DeptWarehouses).HasColumnName("DEPT_WAREHOUSES");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(48)
                    .IsUnicode(false);

                entity.HasOne(d => d.CdeptCompetentionPatternNavigation)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.CdeptCompetentionPattern)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DEPARTMENT_COMPETENTION_PATTERN1");

                entity.HasOne(d => d.DeptAccountsNavigation)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.DeptAccounts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DEPARTMENT_ACCOUNTS1");

                entity.HasOne(d => d.DeptHeadNavigation)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.DeptHead)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DEPARTMENT_WORKERS");

                entity.HasOne(d => d.DeptWarehousesNavigation)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.DeptWarehouses)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DEPARTMENT_WAREHOUSES1");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmailPrivate)
                    .HasColumnName("EMAIL_PRIVATE")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EmailWork)
                    .HasColumnName("EMAIL_WORK")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddress)
                    .HasColumnName("HOME_ADDRESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MedInspectionDate)
                    .HasColumnName("MED_INSPECTION_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalIdnum)
                    .IsRequired()
                    .HasColumnName("PERSONAL_IDNUM")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhonePrivate)
                    .HasColumnName("PHONE_PRIVATE")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneWork)
                    .HasColumnName("PHONE_WORK")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("SURNAME")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Workedtill)
                    .HasColumnName("WORKEDTILL")
                    .HasColumnType("date");

                entity.Property(e => e.Worksfrom)
                    .HasColumnName("WORKSFROM")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.Comment).HasColumnName("COMMENT");

                entity.Property(e => e.ExtCode)
                    .HasColumnName("EXT_CODE")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IntCode)
                    .IsRequired()
                    .HasColumnName("INT_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OrderDate)
                    .HasColumnName("ORDER_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.OrderTypeId).HasColumnName("ORDER_TYPE_ID");

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ProdDate)
                    .HasColumnName("PROD_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.QualityCardId).HasColumnName("QUALITY_CARD_ID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ORDER_CLIENT1");

                entity.HasOne(d => d.OrderType)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ORDER_ORDER_TYPE1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ORDER_PRODUCT1");

                entity.HasOne(d => d.QualityCard)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.QualityCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ORDER_QUALITY_CARD1");
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.ToTable("ORDER_TYPE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("POSITION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Coef)
                    .HasColumnName("COEF")
                    .HasDefaultValueSql("((1.2))");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.MedInspPeriod)
                    .HasColumnName("MED_INSP_PERIOD")
                    .HasDefaultValueSql("((24))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Position)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_POSITION_DEPARTMENT1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QualityCard>(entity =>
            {
                entity.ToTable("QUALITY_CARD");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnName("LINK")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ToolList>(entity =>
            {
                entity.ToTable("TOOL_LIST");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastCheckDate)
                    .HasColumnName("LAST_CHECK_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.ToolPropId).HasColumnName("TOOL_PROP_ID");

                entity.Property(e => e.ToolTypeId).HasColumnName("TOOL_TYPE_ID");

                entity.Property(e => e.ToolUtilized).HasColumnName("TOOL_UTILIZED");

                entity.Property(e => e.WorkerId).HasColumnName("WORKER_ID");

                entity.HasOne(d => d.ToolProp)
                    .WithMany(p => p.ToolList)
                    .HasForeignKey(d => d.ToolPropId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TOOL_LIST_TOOL_PROP1");

                entity.HasOne(d => d.ToolType)
                    .WithMany(p => p.ToolList)
                    .HasForeignKey(d => d.ToolTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TOOL_LIST_TOOL_TYPE1");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.ToolList)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TOOL_LIST_WORKER1");
            });

            modelBuilder.Entity<ToolProp>(entity =>
            {
                entity.ToTable("TOOL_PROP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Prop)
                    .IsRequired()
                    .HasColumnName("PROP")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ToolTypeId).HasColumnName("TOOL_TYPE_ID");

                entity.HasOne(d => d.ToolType)
                    .WithMany(p => p.ToolProp)
                    .HasForeignKey(d => d.ToolTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TOOL_PROP_TOOL_TYPE1");
            });

            modelBuilder.Entity<ToolType>(entity =>
            {
                entity.ToTable("TOOL_TYPE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CheckPeriodMonth)
                    .HasColumnName("CHECK_PERIOD_MONTH")
                    .HasDefaultValueSql("((12))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.ToTable("UNITS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("WAREHOUSE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WhItems>(entity =>
            {
                entity.ToTable("WH_ITEMS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descr)
                    .HasColumnName("DESCR")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("decimal(5, 4)");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.UnitsId).HasColumnName("UNITS_ID");

                entity.Property(e => e.WarehouseId).HasColumnName("WAREHOUSE_ID");

                entity.HasOne(d => d.Units)
                    .WithMany(p => p.WhItems)
                    .HasForeignKey(d => d.UnitsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UNITS_ID1");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.WhItems)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_WH_ITEMS_WAREHOUSE1");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("WORKER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.PositionId).HasColumnName("POSITION_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Worker)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_WORKER_EMPLOYEE1");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Worker)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_WORKER_POSITION1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
