using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Repository
{
    public interface IKnowledgeHubProtalRepository
    {

        #region Catagory CRUD
        bool SaveCatagory(Catagory catagory);
        List<Catagory> GetCatagories();
        Catagory GetCatagory(int id);
        bool RemoveCatagory(int id);
        void EditCatagory(Catagory catagory);
        #endregion

        #region Articles Management




        #endregion
    }
}
