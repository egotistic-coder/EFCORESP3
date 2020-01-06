using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataModel
{
    public class EFContext:DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Query<Subscription>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=TestEF2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

       
    }

    public class EFRepository
    {
        public string ConnectionString { get; set; }

        public void GetSubscription()
        {
            string email = "jojo";

            var connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=TestEF2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();


            var options = new DbContextOptionsBuilder<EFContext>()
                    .UseSqlServer(connection)
                    .Options;

            using (var ctx = new EFContext(options))
            {
                
                SqlParameter value1Input = new SqlParameter("@em", email ?? (object)DBNull.Value);

               
                var subscription = ctx.Query<Subscription>().FromSqlRaw("[dbo].[GetSubscriber] @em", value1Input);
                var subscription1 = ctx.Query<Subscription>().FromSqlRaw("select * from [dbo].[Subscription]");


            }
        }
    }

    public class Subscription
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
    }
}
