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
        Task<string> UploadImage(IFormFile file, string memberName, string phone);


        void UpdateFile(string url);

        //Task Delete (int id);
    }
}
