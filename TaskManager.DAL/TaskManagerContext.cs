﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TaskManager.DAL.Models;

namespace TaskManager.DAL
{
    public class TaskManagerContext : DbContext
    {
        internal DbSet<Project> Projects { get; set; }
        internal DbSet<Employee> Employees { get; set; }
        internal DbSet<Subtask> Subtasks { get; set; }
        internal DbSet<Task> Tasks { get; set; }
        internal DbSet<Team> Teams { get; set; }
        internal DbSet<EmployeeTeam> EmployeeTeams { get; set; }
        internal DbSet<EmployeeTask> EmployeeTasks { get; set; }


        public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies()
        //                  .EnableSensitiveDataLogging()
        //                  .UseSqlServer("Server=.\\SQLEXPRESS;Database=TaskManagerDb;Trusted_Connection=True;");
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                    .HasIndex(u => u.Login)
                    .IsUnique();


            builder.Entity<EmployeeTeam>().HasKey(s => new { s.EmployeeId, s.TeamId });

            builder.Entity<EmployeeTeam>()
                    .HasOne(ss => ss.Employee)
                    .WithMany(s => s.TeamsWithThisEmployee)
                    .HasForeignKey(ss => ss.EmployeeId);

            builder.Entity<EmployeeTeam>()
                    .HasOne(ss => ss.Team)
                    .WithMany(s => s.TeamMembers)
                    .HasForeignKey(ss => ss.TeamId);

            builder.Entity<EmployeeTask>().HasKey(s => new { s.EmployeeId, s.TaskId });

            builder.Entity<EmployeeTask>()
                    .HasOne(ss => ss.Employee)
                    .WithMany(s => s.TasksFromEmployee)
                    .HasForeignKey(ss => ss.EmployeeId);

            builder.Entity<EmployeeTask>()
                    .HasOne(ss => ss.Task)
                    .WithMany(s => s.EmployeesOnTask)
                    .HasForeignKey(ss => ss.TaskId);
        }
    }
}
