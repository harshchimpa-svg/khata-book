
using Microsoft.AspNetCore.Http;

namespace Data.Services;

public interface IFileService
{
    Task<string> UploadImage(IFormFile file, string folderName);
    void DeleteImage(string filePath);
}