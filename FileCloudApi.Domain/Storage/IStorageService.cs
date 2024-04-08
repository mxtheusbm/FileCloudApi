using FileCloudApi.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FileCloudApi.Domain.Storage;
public interface IStorageService
{
    string Upload(IFormFile file, User user);
}
