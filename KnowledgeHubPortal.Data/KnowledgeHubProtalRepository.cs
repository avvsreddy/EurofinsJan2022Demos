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

        public void ApproveArticles(List<int> articleIds)
        {
            List<Article> articlesToApprove = (from a in db.Articles
                                              where articleIds.Contains(a.ArticleID)
                                              select a).ToList();
            foreach (var a in articlesToApprove)
            {
                a.IsApproved = true;
            }
            db.SaveChanges();
        }

        public List<Article> BrowseArticles()
        {
            return db.Articles.Where(a => a.IsApproved).ToList();
        }

        public void EditCatagory(Catagory catagory)
        {
            db.Entry(catagory).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Article> GetArticlesForApprove()
        {
            return db.Articles.Include("Catagory").Where(a => !a.IsApproved).ToList();
        }

        public List<Catagory> GetCatagories()
        {
            return db.Catagories.ToList();
        }

        public Catagory GetCatagory(int id)
        {
            return db.Catagories.Find(id);
        }

        public void RejectArticles(List<int> articleIds)
        {
            List<Article> articlesToReject = (from a in db.Articles
                                               where articleIds.Contains(a.ArticleID)
                                               select a).ToList();
            db.Articles.RemoveRange(articlesToReject);
            db.SaveChanges();
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

        public void SubmitArticle(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();
        }
    }
}
