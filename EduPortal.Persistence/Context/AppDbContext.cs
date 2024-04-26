﻿
using EduPortal.Persistence.Interceptors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using EduPortal.Domain.Entities;
using EduPortal.Models.Entities;
using EduPortal.Models.Configurations;
using EduPortal.Persistence.Configurations;
using EduPortal.Application.Interfaces.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace EduPortal.Persistence.context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>

    {
        IHttpContextAccessor _contextAccessor;
        IDistributedCache _distributedCache;
        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor contextAccessor, IDistributedCache distributedCache)
           : base(options)
        {
            _contextAccessor = contextAccessor;
            _distributedCache = distributedCache;

        }

        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<SubsIndividual> Individuals { get; set; }
        public DbSet<SubsCorporate> Corprorates { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<MeterReading> MeterReadings { get; set; }
        public DbSet<InvoiceComplaint> invoiceComplaints { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<AppUserProfile> Profiles { get; set; }




        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost;Database=EduPortal; Trusted_Connection=true;TrustServerCertificate=True;").AddInterceptors(new SaveChangesInterceptor(_contextAccessor)).UseLazyLoadingProxies()
        //    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //    optionsBuilder.UseLazyLoadingProxies(false);
        //    base.OnConfiguring(optionsBuilder);

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=EduPortal; Trusted_Connection=true;TrustServerCertificate=True;").
                AddInterceptors(new SaveChangesInterceptor(_contextAccessor, _distributedCache)).
                UseLazyLoadingProxies()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseLazyLoadingProxies(false);
            base.OnConfiguring(optionsBuilder);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());


            modelBuilder.Entity<SubsIndividual>().ToTable("SubsIndividuals");
            modelBuilder.Entity<SubsCorporate>().ToTable("SubsCorporates");
            modelBuilder.Entity<SubsCorporate>().ToTable("SubsCorporates");


            var decimalProps = modelBuilder.Model
             .GetEntityTypes()
             .SelectMany(t => t.GetProperties())
               .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in decimalProps)
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
        }


    }

}



//using EduPortal.Persistence.Interceptors;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Options;
//using EduPortal.Domain.Entities;
//using EduPortal.Models.Entities;
//using EduPortal.Models.Configurations;
//using EduPortal.Persistence.Configurations;
//using EduPortal.Application.Interfaces.Services;
//using Microsoft.Extensions.Caching.Distributed;

//namespace EduPortal.Persistence.context
//{
//    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>

//    {
//        IHttpContextAccessor _contextAccessor;
//        IDistributedCache _distributedCache;
//        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor contextAccessor, IDistributedCache distributedCache)
//           : base(options)
//        {
//            _contextAccessor = contextAccessor;
//            _distributedCache = distributedCache;

//        }

//        public DbSet<Subscriber> Subscribers { get; set; }
//        public DbSet<SubsIndividual> Individuals { get; set; }
//        public DbSet<SubsCorporate> Corprorates { get; set; }
//        public DbSet<Invoice> Invoices { get; set; }
//        public DbSet<MeterReading> MeterReadings { get; set; }
//        public DbSet<InvoiceComplaint> invoiceComplaints { get; set; }

//        public DbSet<AppUser> AppUsers { get; set; }
//        public DbSet<AppRole> AppRoles { get; set; }
//        public DbSet<AppUserRole> AppUserRoles { get; set; }
//        public DbSet<AppUserProfile> Profiles { get; set; }




//        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        //{
//        //    optionsBuilder.UseSqlServer("Server=localhost;Database=EduPortal; Trusted_Connection=true;TrustServerCertificate=True;").AddInterceptors(new SaveChangesInterceptor(_contextAccessor)).UseLazyLoadingProxies()
//        //    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//        //    optionsBuilder.UseLazyLoadingProxies(false);
//        //    base.OnConfiguring(optionsBuilder);

//        //}

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer("Server=localhost;Database=EduPortal; Trusted_Connection=true;TrustServerCertificate=True;").
//                AddInterceptors(new SaveChangesInterceptor(_contextAccessor, _distributedCache)).
//                UseLazyLoadingProxies()
//                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//            optionsBuilder.UseLazyLoadingProxies(false);
//            base.OnConfiguring(optionsBuilder);
//        }



//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


//            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
//            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
//            modelBuilder.ApplyConfiguration(new AppUserConfiguration());


//            modelBuilder.Entity<SubsIndividual>().ToTable("SubsIndividuals");
//            modelBuilder.Entity<SubsCorporate>().ToTable("SubsCorporates");
//            modelBuilder.Entity<SubsCorporate>().ToTable("SubsCorporates");


//            var decimalProps = modelBuilder.Model
//             .GetEntityTypes()
//             .SelectMany(t => t.GetProperties())
//               .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

//            foreach (var property in decimalProps)
//            {
//                property.SetPrecision(18);
//                property.SetScale(2);
//            }
//        }


//    }

//}