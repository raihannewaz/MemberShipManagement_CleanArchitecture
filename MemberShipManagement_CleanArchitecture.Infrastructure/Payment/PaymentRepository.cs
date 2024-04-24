using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA.Context;
using MemberShipManagement_CleanArchitecture.Infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;
using static Dapper.SqlMapper;
using MemberShipManagement_CleanArchitecture.Application.Services;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Payment
{
    internal class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext dbContext, IDapperDbContext dapperDb)
        {
            _context = dbContext;
        }

        public async Task CreateAsync(Domain.PaymentEntity.Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }



        public async Task<Domain.PaymentEntity.Payment> GetById(int a)
        {
            return await _context.Payments.FirstOrDefaultAsync(p=>p.PaymentId==a);
        }


        public Task SaveChangeAsync()
        {
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }





    }
}
