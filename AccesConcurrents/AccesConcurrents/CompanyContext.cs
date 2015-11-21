using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesConcurrents
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base(@"Data Source=vm-sql.iesn.be\stu3ig;Initial Catalog=DBIG3A6;User ID=IG3A6;Password=pwUserdb34")
        {
           
        }

        public DbSet<Customer> Customers { get; set; }

    }
}
