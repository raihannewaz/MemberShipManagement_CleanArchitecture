using MemberShipManagement_CleanArchitecture.Domain.Members;

namespace MemberShipManagement_CleanArchitecture.Domain.Documents
{
    public class Document
    {
        public int DocumentId { get; private set; }
        public string DocumentType { get;  private set; }
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
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException("Incorrect type");
            }

            if (memberId <=0)
            {
                throw new ArgumentException("Incorrect MemberId");
            }

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
