﻿using MemberShipManagement_CleanArchitecture.Domain.MemberEntity;
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
        public string? DocumentType { get; private set; }
        public string? DocumentUrl { get; private set; }
        
        public int MemberId { get; private set; }
        public Member? Member { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile? FileType { get; set; }


        private Document() { }


        private Document(string type, IFormFile file, int memberId)
        {
            DocumentType = type;
            FileType = file;
            MemberId = memberId;
        }

        public static Document CreateDoc(string type, IFormFile f, int memberId)
        {
            return new Document(type, f, memberId);
        }


        //public void UpdateDoc(string type, IFormFile file)
        //{
        //    if (type != null)
        //    {
        //        DocumentType = type;
        //    }
        //    if (file != null)
        //    {
        //        FileType = file;
        //    }

        //}


        public void FileUrl(string a)
        {
            DocumentUrl = a;
        }


        public enum EDocumentType
        {
            Nid,
            Utility
        }
    }
}
