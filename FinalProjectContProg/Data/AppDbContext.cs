﻿using Microsoft.EntityFrameworkCore;
using FinalProjectContProg.Models;
using System.Collections.Generic;

namespace FinalProjectContProg.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<FinalProjectContProg.Models.Task> Tasks { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
