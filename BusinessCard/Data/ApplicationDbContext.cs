namespace BusinessCard.Data
{
    using BusinessCard.Data.Entities.Badges;
    using BusinessCard.Data.Entities.BusinessCards;
    using BusinessCard.Data.Entities.Users;
    using BusinessCard.Insfrastructure.Data;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class ApplicationDbContext : IdentityDbContext<
        UserEntity, RoleEntity, Guid, UserClaimEntity, UserRolesEntity, UserLoginEntity, RoleClaimEntity, UserTokenEntity>,
        IAppDbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<BadgeEntity> Badges { get; set; }

        public DbSet<BusinessCardEntity> BusinessCards { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEntity>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            builder.Entity<RoleEntity>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            builder.Entity<UserRolesEntity>(entity =>
            {
                entity.ToTable(name: "UserRoles");
            });

            builder.Entity<UserClaimEntity>(entity =>
            {
                entity.ToTable(name: "UserClaims");
            });

            builder.Entity<RoleClaimEntity>(entity =>
            {
                entity.ToTable(name: "RoleClaims");
            });

            builder.Entity<UserLoginEntity>(entity =>
            {
                entity.ToTable(name: "UserLogins");
            });

            builder.Entity<UserTokenEntity>(entity =>
            {
                entity.ToTable(name: "UserTokens");
            });

            builder.Entity<BusinessCardEntity>(entity =>
            {
                entity.ToTable("BusinessCards");
                entity.HasKey(c => c.Id);
            });
        }
    }
}
