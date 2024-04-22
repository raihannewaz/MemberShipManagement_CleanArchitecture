using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.DuePaymentEntity
{
    public interface IDuePaymentRepository
    {
        Task HandleDuePayments();

        Task<IEnumerable<DuePayment>> GetDuesById(string a);
    }
}
