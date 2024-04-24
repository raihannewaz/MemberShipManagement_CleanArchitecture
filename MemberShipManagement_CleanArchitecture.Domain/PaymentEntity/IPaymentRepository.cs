using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using MemberShipManagement_CleanArchitecture.Domain.PackageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.PaymentEntity
{
    public interface IPaymentRepository
    {
        Task CreateAsync(Payment payment);
        
        Task<Payment> GetById(int a);
        Task SaveChangeAsync();
    }
}
