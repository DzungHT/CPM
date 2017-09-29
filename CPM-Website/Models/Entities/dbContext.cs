namespace CPM_Website.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbContext : DbContext
    {
        public dbContext()
            : base("name=dbContext")
        {
        }

        public virtual DbSet<ActionLog> ActionLogs { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<DomainData> DomainDatas { get; set; }
        public virtual DbSet<DomainType> DomainTypes { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<RoleMenu> RoleMenus { get; set; }
        public virtual DbSet<UserRoleData> UserRoleDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                .HasMany(e => e.DomainTypes)
                .WithMany(e => e.Applications)
                .Map(m => m.ToTable("AppDomainType").MapLeftKey("ApplicationID").MapRightKey("DomainTypeID"));

            modelBuilder.Entity<DomainData>()
                .HasMany(e => e.UserRoleDatas)
                .WithRequired(e => e.DomainData)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.RoleMenus)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Permissions)
                .Map(m => m.ToTable("RolePermission").MapLeftKey("PermissionID").MapRightKey("RoleID"));

            modelBuilder.Entity<Role>()
                .HasMany(e => e.RoleMenus)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.UserRoleDatas)
                .WithRequired(e => e.UserRole)
                .WillCascadeOnDelete(false);
        }
    }
}
