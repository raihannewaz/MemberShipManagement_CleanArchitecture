using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.DTO_s
{
    public class DocumentDTO
    {
        public int DocumentId { get;  set; }
        public string? DocumentType { get;  set; }
        public string? DocumentUrl { get;  set; }

        public int MemberId { get;  set; }
        public MemberDTO? Member { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile? FileType { get; set; }
    }
}
