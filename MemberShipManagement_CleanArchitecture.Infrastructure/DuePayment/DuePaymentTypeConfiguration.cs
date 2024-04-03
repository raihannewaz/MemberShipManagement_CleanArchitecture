using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Infrastructure.DuePayment
{
    internal class DuePaymentTypeConfiguration : IEntityTypeConfiguration<Domain.DuePaymentEntity.DuePayment>
    {
        public void Configure(EntityTypeBuilder<Domain.DuePaymentEntity.DuePayment> builder)
        {
            throw new NotImplementedException();
        }
    }
}
