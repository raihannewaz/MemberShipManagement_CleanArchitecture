using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;
using MemberShipManagement_CleanArchitecture.Application.Services;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Package
{
    internal class PackageRepository : IPackageRepository
    {
        private readonly ApplicationDbContext _context;

        public PackageRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task CreateAsync(Domain.PackageEntity.Package p)
        {
            await _context.Packages.AddAsync(p);
           
        }

        public Task DeleteAsync(Domain.PackageEntity.Package package)
        {
            _context.Packages.Remove(package);
            return Task.CompletedTask;
        }


        public async Task<Domain.PackageEntity.Package> GetById(int a)
        {
            return await _context.Packages.FirstOrDefaultAsync(p => p.PackageId == a);
        }

        public async Task SaveChangeAsync()
        {
           await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Domain.PackageEntity.Package package)
        {
             _context.Entry(package).State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
