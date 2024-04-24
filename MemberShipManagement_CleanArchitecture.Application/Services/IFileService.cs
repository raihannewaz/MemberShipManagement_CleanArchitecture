using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Services
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file);
        void UpdateFile(string url);

        //Task Delete (int id);
    }
}
