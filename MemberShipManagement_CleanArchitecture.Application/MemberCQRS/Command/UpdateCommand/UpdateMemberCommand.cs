using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.MemberCQRS.Command.UpdateCommand
{
    public class UpdateMemberCommand: IRequest<int>
    {
        public int MemberId { get;  set; }
        public string? FirstName { get;  set; }
        public string? LastName { get;  set; }
        public string? Email { get;  set; }
        public string? PhoneNo { get;  set; }
        public DateTime? DOB { get;  set; }
      
        public bool? IsActive { get; set; }

        public IFormFile? ImageFile { get; set; }

    }
}
