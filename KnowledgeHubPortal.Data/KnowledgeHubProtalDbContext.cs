using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Data
{
    internal class KnowledgeHubProtalDbContext : DbContext
    {
        public KnowledgeHubProtalDbContext():base("name=DefaultConnection")
        {

        }

        public DbSet<Catagory> Catagories { get; set; }
    }
}
