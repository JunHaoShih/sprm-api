using Microsoft.EntityFrameworkCore;
using SprmApi.Core.AppUsers;
using SprmApi.Core.Customs;
using SprmApi.Core.MakeTypes;
using SprmApi.Core.ObjectTypes;
using SprmApi.Core.Parts;
using SprmApi.Core.PartUsages;
using SprmApi.Core.Permissions;
using SprmApi.Core.Processes;
using SprmApi.Core.ProcessTypes;
using SprmApi.Core.Routings;
using SprmApi.Core.RoutingUsages;

namespace SprmApi.EFs
{
    /// <summary>
    /// 本系統的DbContext
    /// </summary>
    public class SprmContext : DbContext
    {
        /// <summary>
        /// Constructor, 一定要去base(options)
        /// </summary>
        /// <param name="options"></param>
        public SprmContext(DbContextOptions<SprmContext> options) : base(options)
        { }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Part related
            modelBuilder.Entity<Part>()
                .HasIndex(p => new { p.Number, p.ViewType })
                .IsUnique();

            modelBuilder.Entity<PartVersion>()
                .HasIndex(c => new { c.MasterId, c.Version })
                .IsUnique();

            modelBuilder.Entity<PartUsage>()
                .HasIndex(c => new { c.ParentId, c.ChildId })
                .IsUnique();

            modelBuilder.Entity<Routing>()
                .HasIndex(c => new { c.PartId, c.Name })
                .IsUnique();

            modelBuilder.Entity<RoutingVersion>()
                .HasIndex(c => new { c.MasterId, c.Version })
                .IsUnique();

            modelBuilder.Entity<Process>()
                .HasIndex(c => new { c.Number })
                .IsUnique();

            modelBuilder.Entity<ProcessType>()
                .HasIndex(c => new { c.Number })
                .IsUnique();

            modelBuilder.Entity<MakeType>()
                .HasIndex(c => new { c.Number })
                .IsUnique();

            modelBuilder.Entity<ObjectType>()
                .HasIndex(c => new { c.Number })
                .IsUnique();

            modelBuilder.Entity<CustomAttribute>()
                .HasIndex(c => new { c.Number })
                .IsUnique();

            modelBuilder.Entity<AttributeLink>()
                .HasIndex(c => new { c.ObjectTypeId, c.AttributeId })
                .IsUnique();

            modelBuilder.Entity<RoutingUsage>()
                .HasIndex(c => new { c.RootVersionId, c.Number })
                .IsUnique();

            // Set constraints

            // Restrict part delete if routing exist
            modelBuilder.Entity<Routing>()
                .HasOne(r => r.Part)
                .WithMany(p => p.Routings)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Restrict process type delete if any process is using this process type
            modelBuilder.Entity<Process>()
                .HasOne(p => p.ProcessType)
                .WithMany(pt => pt.Processes)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Restrict make type delete if any process is using this make type
            modelBuilder.Entity<Process>()
                .HasOne(p => p.MakeType)
                .WithMany(mt => mt.Processes)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Restrict process delete if any routing usage is using this process
            modelBuilder.Entity<RoutingUsage>()
                .HasOne(ru => ru.Process)
                .WithMany(p => p.RoutingUsages)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Restrict part delete if any part usage is using this part
            modelBuilder.Entity<PartUsage>()
                .HasOne(pu => pu.Child)
                .WithMany(p => p.ParentPartUsages)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MakeType>().HasData(GetDefaultMakeTypes());
            modelBuilder.Entity<ProcessType>().HasData(GetDefaultProcessTypes());
            modelBuilder.Entity<ObjectType>().HasData(GetDefaultObjectTypes());
        }

        private static IEnumerable<MakeType> GetDefaultMakeTypes()
        {
            List<MakeType> makeTypes = new List<MakeType>();

            makeTypes.Add(new MakeType
            {
                Id = 1,
                Remarks = "System default, do not modify it",
                Number = "SPRM_SELF_MADE",
                Name = "自製",
                IsSystemDefault = true,
            });
            makeTypes.Add(new MakeType
            {
                Id = 2,
                Remarks = "System default, do not modify it",
                Number = "SPRM_OUTSOURCE",
                Name = "外包",
                IsSystemDefault = true,
            });

            return makeTypes;
        }

        private static IEnumerable<ObjectType> GetDefaultObjectTypes()
        {
            List<ObjectType> objTypes = new List<ObjectType>();

            objTypes.Add(new ObjectType
            {
                Id = (long)SprmObjectType.PartVersion,
                Remarks = "料件",
                Number = typeof(PartVersion).Name,
                Name = "料件"
            });

            objTypes.Add(new ObjectType
            {
                Id = (long)SprmObjectType.PartUsage,
                Remarks = "料件使用關係",
                Number = typeof(PartUsage).Name,
                Name = "料件使用關係"
            });

            objTypes.Add(new ObjectType
            {
                Id = (long)SprmObjectType.Routing,
                Remarks = "工藝路徑",
                Number = typeof(Routing).Name,
                Name = "工藝路徑"
            });

            objTypes.Add(new ObjectType
            {
                Id = (long)SprmObjectType.RoutingVersion,
                Remarks = "工藝路徑版本",
                Number = typeof(RoutingVersion).Name,
                Name = "工藝路徑版本"
            });

            objTypes.Add(new ObjectType
            {
                Id = (long)SprmObjectType.Process,
                Remarks = "製程",
                Number = typeof(Process).Name,
                Name = "製程"
            });

            objTypes.Add(new ObjectType
            {
                Id = (long)SprmObjectType.RoutingUsage,
                Remarks = "工藝路徑使用關係",
                Number = typeof(RoutingUsage).Name,
                Name = "工藝路徑使用關係"
            });

            return objTypes;
        }

        private static IEnumerable<ProcessType> GetDefaultProcessTypes()
        {
            List<ProcessType> processTypes = new List<ProcessType>();

            processTypes.Add(new ProcessType
            {
                Id = 1,
                Remarks = "System default, do not modify it",
                Number = "SPRM_PROCESSING",
                Name = "加工製程",
                IsSystemDefault = true,
            });
            processTypes.Add(new ProcessType
            {
                Id = 2,
                Remarks = "System default, do not modify it",
                Number = "SPRM_QUALITY_CONTROL",
                Name = "檢驗製程",
                IsSystemDefault = true,
            });
            processTypes.Add(new ProcessType
            {
                Id = 3,
                Remarks = "System default, do not modify it",
                Number = "SPRM_ASSEMBLE",
                Name = "組裝製程",
                IsSystemDefault = true,
            });
            processTypes.Add(new ProcessType
            {
                Id = 4,
                Remarks = "System default, do not modify it",
                Number = "SPRM_TRANSPORT",
                Name = "運輸製程",
                IsSystemDefault = true,
            });

            return processTypes;
        }

        /// <summary>
        /// 零件
        /// </summary>
        public virtual DbSet<Part> Parts => Set<Part>();

        /// <summary>
        /// 零件使用關係
        /// </summary>
        public virtual DbSet<PartUsage> PartUsages => Set<PartUsage>();

        /// <summary>
        /// 零件版本
        /// </summary>
        public virtual DbSet<PartVersion> PartVersions => Set<PartVersion>();

        /// <summary>
        /// 產品途程
        /// </summary>
        public virtual DbSet<Routing> Routings => Set<Routing>();

        /// <summary>
        /// 產品途程版本
        /// </summary>
        public virtual DbSet<RoutingVersion> RoutingVersions => Set<RoutingVersion>();

        /// <summary>
        /// 工藝路徑使用關係
        /// </summary>
        public virtual DbSet<RoutingUsage> RoutingUsages => Set<RoutingUsage>();

        /// <summary>
        /// 製程
        /// </summary>
        public virtual DbSet<Process> Processes => Set<Process>();

        /// <summary>
        /// 製程類型
        /// </summary>
        public virtual DbSet<ProcessType> ProcessTypes => Set<ProcessType>();

        /// <summary>
        /// 製造類型
        /// </summary>
        public virtual DbSet<MakeType> MakeTypes => Set<MakeType>();

        /// <summary>
        /// 物件類型
        /// </summary>
        public virtual DbSet<ObjectType> ObjectTypes => Set<ObjectType>();

        /// <summary>
        /// 自訂屬性
        /// </summary>
        public virtual DbSet<CustomAttribute> CustomAttributes => Set<CustomAttribute>();

        /// <summary>
        /// 類型屬性
        /// </summary>
        public virtual DbSet<AttributeLink> AttributeLinks => Set<AttributeLink>();

        /// <summary>
        /// AppUser
        /// </summary>
        public virtual DbSet<AppUser> AppUsers => Set<AppUser>();

        /// <summary>
        /// 權限
        /// </summary>
        public virtual DbSet<Permission> Permissions => Set<Permission>();
    }
}
