using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.DocumentCQRS.Command.CreateCommand
{
    internal sealed class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Document>
    {
        private readonly IDocumentRepository _docRepo;

        public CreateDocumentCommandHandler(IDocumentRepository documentRepository)
        {
            _docRepo = documentRepository;
        }

        public async Task<Document> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = Document.CreateDoc(request.DocumentType, request.FileType, request.MemberId);
                await _docRepo.CreateAync(data);
                await _docRepo.SaveChangeAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
