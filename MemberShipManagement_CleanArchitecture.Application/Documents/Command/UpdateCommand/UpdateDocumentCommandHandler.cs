using MediatR;
using MemberShipManagement_CleanArchitecture.Domain.DocumentEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Documents.Command.UpdateCommand
{
    internal sealed class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, int>
    {
        private readonly IDocumentRepository _document;

        public UpdateDocumentCommandHandler(IDocumentRepository document)
        {
            _document = document;
        }

        public async Task<int> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var member = await _document.GetById(request.MemberId, request.DocType);
            member.UpdateDoc(request.FileType);
            await _document.UpdateAsync(member);
            await _document.SaveChangeAsync();
            return request.MemberId;
        }
    }
}
