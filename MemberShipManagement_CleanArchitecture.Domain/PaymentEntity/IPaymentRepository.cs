using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.PaymentEntity
{
    public interface IPaymentRepository
    {
        Task<Payment> CreateAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(Payment payment);
        Task<IEnumerable<Payment>> GetByIdSql(string a);
        Task<Payment> GetById(int a);

        Task SaveChangeAsync();
    }
}
