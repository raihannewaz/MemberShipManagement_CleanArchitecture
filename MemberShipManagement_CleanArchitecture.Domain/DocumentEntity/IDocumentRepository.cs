using MemberShipManagement_CleanArchitecture.Domain.AddressEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.DocumentEntity
{
    public interface IDocumentRepository
    {
        Task CreateAync(Document a);
        Task UpdateAsync(Document a);

        Task<Document> GetById(int id, string type);
        Task SaveChangeAsync();
    }
}
