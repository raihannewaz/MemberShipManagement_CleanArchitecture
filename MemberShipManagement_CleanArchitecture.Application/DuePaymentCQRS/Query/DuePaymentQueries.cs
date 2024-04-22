using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.DuePaymentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.DuePaymentCQRS.Query
{
    public class DuePaymentQueries: IRequest<IEnumerable<DuePayment>>
    {
        public int MembershipId;

        public string Query;

        public string getMemberDues(int id)
        {
            return @$"SELECT DueDate, Amount FROM DuePayments WHERE MembershipId = {id}
                      SELECT InstallmentAmount FROM Memberships WHERE MembershipId = {id}
                      SELECT FirstName, LastName, PhoneNo, DOB FROM Members
                      SELECT PackageName, PackageType FROM Packages" ;
        }


    }
}
