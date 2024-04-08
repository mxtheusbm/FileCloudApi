using FileCloudApi.Application.UseCases.Users.UploadProfilePhoto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileCloudApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{
    [HttpPost]
    public IActionResult UploadImage([FromServices] IUploadProfilePhotoUseCase useCase, IFormFile file)
    {
        useCase.Execute(file);

        return Created();
    }
}
