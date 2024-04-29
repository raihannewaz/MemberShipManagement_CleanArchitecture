

namespace MemberShipManagement_CleanArchitecture.Application.Services
{
    public interface IFileService
    {
        Task<string> UploadImage(IFormFile file, string memberName, string phone);
        void UpdateFile(string url);

    }
}
