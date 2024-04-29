
namespace MemberShipManagement_CleanArchitecture.Application.Documents.Command.CreateCommand
{
    public class CreateDocumentCommand : IRequest<Document>
    {

        public string? DocumentType { get; set; }
        public int MemberId { get; set; }

        public IFormFile? FileType { get; set; }
    }
}
