
namespace MemberShipManagement_CleanArchitecture.Application.Documents.Command.UpdateCommand
{
    public class UpdateDocumentCommand : IRequest<int>
    {
        public int MemberId { get; set; }
        public string DocType { get; set; }

        public IFormFile FileType { get; set; }
    }
}
