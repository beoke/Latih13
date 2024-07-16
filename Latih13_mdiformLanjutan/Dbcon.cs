using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latih13_mdiformLanjutan
{
    public class Dbcon : DbContext
    {
        public DbSet<SiswaModel> siswa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Server=dev.smart-ics.com;Database=DbKerjaPraktek;User Id=KpLogin;Password=K3rjaPraktekLogin;TrustServerCertificate=True");
        }
    }
}
