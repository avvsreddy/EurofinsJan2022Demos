using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Data
{
    public class KnowledgeHubProtalRepository : IKnowledgeHubProtalRepository
    {
        private readonly KnowledgeHubProtalDbContext db = new KnowledgeHubProtalDbContext();
        public bool SaveCatagory(Catagory catagory)
        {
            db.Catagories.Add(catagory);
            int count = db.SaveChanges();
            return count >= 1;
        }
    }
}
