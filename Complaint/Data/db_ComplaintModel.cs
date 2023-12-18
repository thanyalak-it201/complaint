using Complaint.Models;
using Microsoft.EntityFrameworkCore;

namespace Complaint.Data
{
    public class db_ComplaintModel : DbContext
    {
        public db_ComplaintModel(DbContextOptions<db_ComplaintModel> options) :base(options){ 

        }
        public DbSet<Costomer> Codtomers { get; set; }
        public DbSet<From> From { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Problem> Problem { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<TypeFrom> TypeFrom {  get; set; }
    }
}
