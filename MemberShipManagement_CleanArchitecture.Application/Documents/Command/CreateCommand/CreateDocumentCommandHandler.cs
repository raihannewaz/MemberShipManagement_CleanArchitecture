using MediatR;
using MemberShipManagement_CleanArchitecture.Application.Services;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Documents.Command.CreateCommand
{
    internal sealed class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Document>
    {
        private readonly IDocumentRepository _docRepo;
        private readonly IFileService _fileService;

        public CreateDocumentCommandHandler(IDocumentRepository documentRepository,IFileService fileService)
        {
            _docRepo = documentRepository;
            _fileService = fileService;
        }

        public async Task<Document> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = Document.CreateDoc(request.DocumentType, request.MemberId);
                
                if (request.FileType != null)
                {
                    var url =  await _fileService.UploadFile(request.FileType);
                    data.FileUrl(url);
                }
               
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
