using MemberShipManagement_CleanArchitecture.Domain.PaymentEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MemberShipManagement_CleanArchitecture.Infrastructure.Payment
{
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<Domain.PaymentEntity.Payment>
    {
        public void Configure(EntityTypeBuilder<Domain.PaymentEntity.Payment> builder)
        {
            throw new NotImplementedException();
        }
    }
}
