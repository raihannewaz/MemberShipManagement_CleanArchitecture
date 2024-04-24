using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Domain.DocumentEntity
{
    public class Document
    {
        public int DocumentId { get; private set; }
        private string DocumentType { get;  set; }
        private string DocumentUrl { get;  set; }

        public int MemberId { get; private set; }
        private Member? Member { get; set; }


        private Document() { }


        private Document(string type, int memberId)
        {
            DocumentType = type;
            MemberId = memberId;
        }

        public static Document CreateDoc(string type, int memberId)
        {
            return new Document(type, memberId);
        }



        public void FileUrl(string a)
        {
            DocumentUrl = a;
        }

        public string GetDocumentUrl()
        {
            return DocumentUrl;
        }

        public string GetDocumentType()
        {
            return DocumentType;
        }

        public enum EDocumentType
        {
            Nid,
            Utility
        }
    }
}
