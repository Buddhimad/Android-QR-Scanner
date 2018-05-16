using ijse.pos.Common.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijse.pos.DataAccess.DAL
{
    public class POSContext:DbContext
    {
        public POSContext() : base("MYDB")
        {
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
