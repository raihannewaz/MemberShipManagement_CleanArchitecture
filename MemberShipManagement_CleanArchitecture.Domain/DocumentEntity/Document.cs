using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.DocumentEntity
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentUrl { get; set; }
        
        public int MemberId { get; set; }
        public Member? Member { get; set; }


        public IFormFile? NidFile { get; set; }
        public IFormFile? UtilityBillFile { get; set; }


        public enum EDocumentType
        {
            Nid,
            Utility
        }
    }
}
