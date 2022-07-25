using MongoDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Services
{
    public interface IContactService
    {
         Task<IList<Contact>> GetAsync();
    }
}
