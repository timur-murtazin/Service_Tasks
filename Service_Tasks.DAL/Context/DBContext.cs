using Service_Tasks.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Service_Tasks.DAL.Context
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) 
        {
            
        }

        public DbSet<TaskEntity> Tasks { get; set; }

        /*public static List<TaskEntity> Tasks = new List<TaskEntity>()
        {
            new TaskEntity()
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Status = "In progress",
                CreatedDate = DateTime.Now
            },
            new TaskEntity()
            {
                Id = 2,
                Title = "Test",
                Description = "Test",
                Status = "On tests",
                CreatedDate = DateTime.Now
            }
        };*/

    }
}
