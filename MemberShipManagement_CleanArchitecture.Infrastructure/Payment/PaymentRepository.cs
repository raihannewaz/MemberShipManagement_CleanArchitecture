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

namespace MemberShipManagement_CleanArchitecture.Infrastructure.Payment
{
    internal class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DapperDbContext _dapperDbContext;

        public PaymentRepository(ApplicationDbContext dbContext, DapperDbContext dapperDb)
        {
            _context = dbContext;
            _dapperDbContext = dapperDb;
        }

        public async Task<Domain.PaymentEntity.Payment> CreateAsync(Domain.PaymentEntity.Payment payment)
        {
            var date = DateTime.Now;
            payment.AutoSetPaymentDate(date);
            await _context.Payments.AddAsync(payment);

            var membership = await _context.Memberships.FindAsync(payment.MembershipId);

            if (membership == null)
            {
                throw new ArgumentException("Invalid MembershipID");
            }

            int installmentMinus = 0;

            if (payment.PaidAmmount == membership.InstallmentAmount)
            {
                installmentMinus = membership.TotalInstallment - 1;
            }
            //else if (payment.PaidAmmount > membership.InstallmentAmount)
            //{
            //    installmentMinus = (membership.TotalInstallment * (int)membership.InstallmentAmount - (int)payment.PaidAmmount) / 100 ;
            //}
            else if (payment.AdvanceInstallMent >=2)
            {
                installmentMinus = (membership.TotalInstallment - 1) - payment.AdvanceInstallMent;
            }

            membership.InstallmentCalculateWithPayment(installmentMinus);


            return payment;
        }

        public Task DeleteAsync(Domain.PaymentEntity.Payment payment)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Domain.PaymentEntity.Payment>> GetAllAsync(string a)
        {
            using (var con = _dapperDbContext.CreateConnection())
            {
                var result = await con.QueryAsync<Domain.PaymentEntity.Payment>(a);

                return result.ToList();
            }
        }

        public async Task<Domain.PaymentEntity.Payment> GetById(int a)
        {
            return await _context.Payments.FirstOrDefaultAsync(p=>p.PaymentId==a);
        }

        public Task<IEnumerable<Domain.PaymentEntity.Payment>> GetByIdSql(string a)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangeAsync()
        {
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Domain.PaymentEntity.Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
