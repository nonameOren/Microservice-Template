﻿using Calabonga.AspNetCore.Micro.Data.Base;
using Calabonga.AspNetCore.Micro.Models;
using Microsoft.EntityFrameworkCore;

namespace Calabonga.AspNetCore.Micro.Data
{
    /// <summary>
    /// Database for application
    /// </summary>
    public class ApplicationDbContext : DbContextBase, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        #region System

        public DbSet<Log> Logs { get; set; }

        public DbSet<ApplicationUserProfile> Profiles { get; set; }

        #endregion
    }
}