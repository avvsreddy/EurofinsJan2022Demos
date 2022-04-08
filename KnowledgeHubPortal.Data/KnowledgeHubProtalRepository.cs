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

        public void EditCatagory(Catagory catagory)
        {
            db.Entry(catagory).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Catagory> GetCatagories()
        {
            return db.Catagories.ToList();
        }

        public Catagory GetCatagory(int id)
        {
            return db.Catagories.Find(id);
        }

        public bool RemoveCatagory(int id)
        {
            var cat = db.Catagories.Remove(GetCatagory(id));
            db.SaveChanges();
            if (cat != null)
                return true;
            return false;

        }

        public bool SaveCatagory(Catagory catagory)
        {
            db.Catagories.Add(catagory);
            int count = db.SaveChanges();
            return count >= 1;
        }
    }
}
