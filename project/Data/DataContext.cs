using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project;

namespace Project.Data
{
    public class DataContext : DbContext
    {
     
        public DataContext(DbContextOptions <DataContext> options) : base(options)
        { 
        
        }


        public DbSet<Project> Projects { get; set; }



    }

      
   



}

