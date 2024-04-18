using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.DocumentCQRS.Command.CreateCommand
{
    public class CreateDocumentCommand :  IRequest<Document>
    {

        public string? DocumentType { get;  set; }
        public int MemberId { get;  set; }

        public IFormFile? FileType { get; set; }
    }
}
