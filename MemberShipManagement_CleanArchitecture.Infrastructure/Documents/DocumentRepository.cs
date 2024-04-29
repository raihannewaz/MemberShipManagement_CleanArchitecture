
namespace MemberShipManagement_CleanArchitecture.Infrastructure.Documents
{
    internal class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task CreateAync(Document a)
        {
            await _context.Documents.AddAsync(a);
        }


        public async Task<Document> GetById(int id, string type)
        {
            return await _context.Documents.FirstOrDefaultAsync(d=>d.MemberId ==  id && d.DocumentType == type);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Document a)
        {
            _context.Entry(a).State = EntityState.Modified;
            return Task.CompletedTask;
        }


      

        //private bool IsImageFileValid(string fileName)
        //{
        //    string extension = Path.GetExtension(fileName).ToLower();
        //    return extension == ".jpg" || extension == ".jpeg" || extension == ".png";
        //}
    }
}
