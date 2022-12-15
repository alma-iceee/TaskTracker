using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;

namespace TaskTracker.Data
{
    /// <summary>
    ///     A class for an database context <see cref="DbContext"/>.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        private readonly ILogger<ApplicationDbContext> _logger;

        /// <summary>
        ///     Gets or sets an database set of the <see cref="Project"/>" class.
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        ///     Gets or sets an database set of the <see cref="Models.Task"/>" class.
        /// </summary>
        public DbSet<Models.Task> Tasks { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationDbContext"/>" class. Calling methods that
        ///     deletes and creates database.
        /// </summary>
        /// <param name="logger">An injected logger <see cref="ILogger"/></param>
        /// <param name="options">The options for this context</param>
        public ApplicationDbContext(ILogger<ApplicationDbContext> logger, DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _logger = logger;

            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        /// <summary>
        ///     Overrided method to seed entites.
        /// </summary>
        /// <param name="modelBuilder">
        ///     The builder being used to construct the model for this context. Databases (and other extensions) typically
        ///     define extension methods on this object that allow you to configure aspects of the model that are specific
        ///     to a given database.
        ///     <see cref="ModelBuilder"/>
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var project1 = new Project
            {
                Id = 1,
                Name = "Project1",
                StartDate = DateTime.Now,
                Status = Models.Enums.ProjectStatus.NotStarted,
                Priority = 1
            };
            modelBuilder.Entity<Project>().HasData(project1);

            var project2 = new Project
            {
                Id = 2,
                Name = "Project2",
                StartDate = DateTime.Now,
                Status = Models.Enums.ProjectStatus.NotStarted,
                Priority = 2
            };
            modelBuilder.Entity<Project>().HasData(project2);

            var project3 = new Project
            {
                Id = 3,
                Name = "Project3",
                StartDate = DateTime.Now,
                Status = Models.Enums.ProjectStatus.NotStarted,
                Priority = 3
            };
            modelBuilder.Entity<Project>().HasData(project3);

            var task1 = new Models.Task
            {
                Id = 1,
                Name = "Task1",
                Description = "Description1",
                Status = Models.Enums.TaskStatus.ToDo,
                Priority = 1,
                ProjectId = project1.Id
            };
            modelBuilder.Entity<Models.Task>().HasData(task1);

            var task2 = new Models.Task
            {
                Id = 2,
                Name = "Task2",
                Description = "Description2",
                Status = Models.Enums.TaskStatus.ToDo,
                Priority = 2,
                ProjectId = project1.Id
            };
            modelBuilder.Entity<Models.Task>().HasData(task2);

            var task3 = new Models.Task
            {
                Id = 3,
                Name = "Task3",
                Description = "Description3",
                Status = Models.Enums.TaskStatus.ToDo,
                Priority = 1,
                ProjectId = project2.Id
            };
            modelBuilder.Entity<Models.Task>().HasData(task3);

            var task4 = new Models.Task
            {
                Id = 4,
                Name = "Task4",
                Description = "Description4",
                Status = Models.Enums.TaskStatus.ToDo,
                Priority = 2,
                ProjectId = project2.Id
            };
            modelBuilder.Entity<Models.Task>().HasData(task4);

            var task5 = new Models.Task
            {
                Id = 5,
                Name = "Task5",
                Description = "Description5",
                Status = Models.Enums.TaskStatus.ToDo,
                Priority = 1,
                ProjectId = project3.Id
            };
            modelBuilder.Entity<Models.Task>().HasData(task5);

            var task6 = new Models.Task
            {
                Id = 6,
                Name = "Task6",
                Description = "Description6",
                Status = Models.Enums.TaskStatus.ToDo,
                Priority = 2,
                ProjectId = project3.Id
            };
            modelBuilder.Entity<Models.Task>().HasData(task6);
        }
    }
}
