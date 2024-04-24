using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using Microsoft.EntityFrameworkCore;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Document
{
    internal class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task CreateAync(Domain.DocumentEntity.Document a)
        {
            await _context.Documents.AddAsync(a);
        }


        public async Task<Domain.DocumentEntity.Document> GetById(int id, string type)
        {
            return await _context.Documents.FirstOrDefaultAsync(d=>d.MemberId ==  id && d.GetDocumentType() == type);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Domain.DocumentEntity.Document a)
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
