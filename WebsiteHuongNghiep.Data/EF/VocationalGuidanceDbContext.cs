﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Data.EF
{
    public class VocationalGuidanceDbContext : IdentityDbContext<User, Role, Guid>
    {
        public VocationalGuidanceDbContext(DbContextOptions<VocationalGuidanceDbContext> options)
        : base(options)
        {
        }
        public DbSet<HollandMultipleChoice> HollandMultipleChoices { get; set; }
        public DbSet<HollandTracker> HollandTrackers { get; set; }
        public DbSet<HollandScore> HollandScores { get; set; }
        public DbSet<HollandTable> HollandTables { get; set; }
        public DbSet<HollandResult> HollandResults { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MbtiTable> MbtiTables { get; set; }
        public DbSet<MbtiResult> MbtiResults { get; set; }
        public DbSet<MbtiTracker> MbtiTrackers { get; set; }
        public DbSet<BigFiveResult> BigFiveResults { get; set; }
        public DbSet<BigFiveQuestion> BigFiveQuestions { get; set; }
        public DbSet<BigFiveTracker> BigFiveTrackers { get; set; }
        public DbSet<EnnegramResult> EnnegramResults { get; set; }
        public DbSet<EnnegramTracker> EnnegramTrackers { get; set; }
        public DbSet<MITable> MITables { get; set; }
        public DbSet<MIQuestion> MIQuestions { get; set; }
        public DbSet<MITracker> MITrackers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 
            modelBuilder.Entity<HollandTable>().ToTable("HollandTables").HasKey(e => e.HLTableId);
            modelBuilder.Entity<HollandTable>(e => {
                e.Property(ht => ht.Name).HasColumnType("nvarchar(150)");
            });


            //
            modelBuilder.Entity<HollandMultipleChoice>().ToTable("HollandMultipleChoices").HasKey(e => e.Id);
            //define relationship between HollandTable and HollandMultipleChoice
            modelBuilder.Entity<HollandMultipleChoice>().HasOne(hm => hm.HollandTable)
                                                        .WithMany(ht => ht.HollandMutipleChoices)
                                                        .HasForeignKey(hm => hm.HLTableId);
            modelBuilder.Entity<HollandMultipleChoice>(e => {
                e.Property(hm => hm.Question).HasColumnType("nvarchar(250)");

            });


            //
            modelBuilder.Entity<HollandTracker>().ToTable("HollandTrackers").HasKey(e => e.Id);
            modelBuilder.Entity<HollandTracker>(e => {
                e.Property(ht => ht.TimeStamp).HasColumnType("varchar(50)");
                e.HasOne(ht => ht.User).WithMany(u => u.HollandTrackers).HasForeignKey(ht => ht.UserId);
            });


            //
            modelBuilder.Entity<HollandScore>().ToTable("HollandScore").HasKey(e => e.Id);
            modelBuilder.Entity<HollandScore>(e => {
                e.Property(hs => hs.TimeStamp).HasColumnType("varchar(50)");
            });


            //
            modelBuilder.Entity<HollandResult>().ToTable("HollandResult").HasKey(e => e.Id);
            modelBuilder.Entity<HollandResult>(e => {
                e.Property(hr => hr.Result).HasColumnType("ntext");
            });

            //
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>(e => {
                e.Property(u => u.FirstName).HasMaxLength(100);
                e.Property(u => u.LastName).HasMaxLength(100);
            });

            //
            modelBuilder.Entity<Blog>().ToTable("Blogs").HasKey(x => x.Id);
            modelBuilder.Entity<Blog>(e => {
                e.Property(b => b.Content).HasColumnType("ntext");
            });

            //
            modelBuilder.Entity<Category>().ToTable("Categories").HasKey(x => x.Id);
            modelBuilder.Entity<Blog>().HasOne(b => b.Category)
                                       .WithMany(c => c.Blogs)
                                       .HasForeignKey(b => b.CategoryId);


            //
            modelBuilder.Entity<MbtiTracker>().ToTable("MbtiTrackers").HasKey(e => e.Id);
            modelBuilder.Entity<MbtiTracker>(e => {
                e.Property(mt => mt.TimeStamp).HasColumnType("varchar(50)");
                e.HasOne(ht => ht.User).WithMany(u => u.MbtiTrackers).HasForeignKey(ht => ht.UserId);
            });

            //
            modelBuilder.Entity<MbtiTable>().ToTable("MbtiTables").HasKey(e => e.Id);
            modelBuilder.Entity<MbtiTable>(e => { e.Property(mt => mt.Position).HasColumnType("int"); });
            //
            modelBuilder.Entity<MbtiResult>().ToTable("MbtiResults").HasKey(e => e.Id);
            modelBuilder.Entity<MbtiResult>(e => 
            {
                e.Property(mr => mr.Explaination).HasColumnType("ntext");
            });


            //
            modelBuilder.Entity<BigFiveResult>().ToTable("BigFiveResults").HasKey(e => e.Id);
            modelBuilder.Entity<BigFiveResult>(e => { e.Property(b => b.Result).HasColumnType("ntext"); });

            //
            modelBuilder.Entity<BigFiveQuestion>().ToTable("BigFiveQuestions").HasKey(e => e.Id);
            modelBuilder.Entity<BigFiveQuestion>().HasOne(b => b.BigFiveResult)
                                                  .WithMany(q => q.BigFiveQuestions)
                                                  .HasForeignKey(b => b.BigFiveResultId);

            //
            modelBuilder.Entity<BigFiveTracker>().ToTable("BigFiveTrackers").HasKey(e => e.Id);
            modelBuilder.Entity<BigFiveTracker>().HasOne(bft => bft.User).WithMany(u => u.BigFiveTrackers).HasForeignKey(bft => bft.UserId);

            //
            modelBuilder.Entity<EnnegramResult>().ToTable("EnnegramResults").HasKey(e => e.Id);

            //
            modelBuilder.Entity<EnnegramTracker>().ToTable("EnnegramTrackers").HasKey(e => e.Id);
            modelBuilder.Entity<EnnegramTracker>().HasOne(et => et.User).WithMany(u => u.EnnegramTrackers).HasForeignKey(et => et.UserId);

            //
            modelBuilder.Entity<MITable>().ToTable("MITables").HasKey(e => e.Id);
            modelBuilder.Entity<MIQuestion>().ToTable("MIQuestions").HasKey(e => e.Id);
            modelBuilder.Entity<MIQuestion>().HasOne(mq => mq.MITable).WithMany(mt => mt.MIQuestions).HasForeignKey(mq => mq.TableId);

            modelBuilder.Entity<MITracker>().ToTable("MITrackers").HasKey(e => e.Id);
            modelBuilder.Entity<MITracker>().HasOne(et => et.User).WithMany(u => u.MITrackers).HasForeignKey(et => et.UserId);

            //
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(x => new {x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);


            //data seeding
            // any guid
            var roleId = new Guid("A01AB883-D923-4C7D-BF6F-42D1592F2280");
            var adminId = new Guid("1C2E9655-416B-4FF8-9413-1E1D13E0F403");
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            }, new Role
            {
                Id = new Guid("EF936E2F-D09A-4FDF-8842-459ED6350702"),
                Name = "student",
                NormalizedName = "student",
                Description = "Role student for person study in university"
            }, new Role
            {
                Id = new Guid("F39A6BA2-D19F-49BA-B75E-2F5C4F1AAAF2"),
                Name = "pupil",
                NormalizedName = "pupil",
                Description = "Role pupil for person study in school (under 18)"
            }); 

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "abcxyz@gmail.com",
                NormalizedEmail = "abcxyz@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abc135"),
                SecurityStamp = string.Empty,
                FirstName = "Anh",
                LastName = "Quang",
                DoB = new DateTime(1998, 02, 23)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
            //end data seeding
        }
    }
}
