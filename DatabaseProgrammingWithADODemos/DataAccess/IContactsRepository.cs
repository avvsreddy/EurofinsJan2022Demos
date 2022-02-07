using DatabaseProgrammingWithADODemos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProgrammingWithADODemos.DataAccess
{
    public interface IContactsRepository
    {
        bool SaveContact(Contact contact);
    }
}
