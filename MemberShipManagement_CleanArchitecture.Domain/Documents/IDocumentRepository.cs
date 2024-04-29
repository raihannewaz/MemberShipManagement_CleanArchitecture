

namespace MemberShipManagement_CleanArchitecture.Domain.Documents
{
    public interface IDocumentRepository
    {
        Task CreateAync(Document a);
        Task UpdateAsync(Document a);

        Task<Document> GetById(int id, string type);
        Task SaveChangeAsync();
    }
}
