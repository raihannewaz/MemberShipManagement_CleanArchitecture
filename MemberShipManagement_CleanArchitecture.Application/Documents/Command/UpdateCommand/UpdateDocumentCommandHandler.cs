



namespace MemberShipManagement_CleanArchitecture.Application.Documents.Command.UpdateCommand
{
    internal sealed class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, int>
    {
        private readonly IDocumentRepository _document;
        private readonly IMemberRepository _memberRepository;
        private readonly IFileService _fileService;

        public UpdateDocumentCommandHandler(IDocumentRepository document,IMemberRepository memberRepository, IFileService fileService)
        {
            _document = document;
            _memberRepository = memberRepository;
            _fileService = fileService;
        }

        public async Task<int> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            

            var member = await _document.GetById(request.MemberId, request.DocType);
            if (request.FileType != null)
            {
                _fileService.UpdateFile(member.GetDocumentUrl());
                var memberNemandPhone = await _memberRepository.GetById(request.MemberId);
                var url = await _fileService.UploadImage(request.FileType,memberNemandPhone.GetLatName(), memberNemandPhone.GetPhone());
                member.FileUrl(url);
            }

            await _document.UpdateAsync(member);
            await _document.SaveChangeAsync();
            return request.MemberId;
        }
    }
}
