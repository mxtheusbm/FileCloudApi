using FileCloudApi.Domain.Entities;
using FileCloudApi.Domain.Storage;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace FileCloudApi.Application.UseCases.Users.UploadProfilePhoto;

public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase
{
    private readonly IStorageService _storageService;
    public UploadProfilePhotoUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public void Execute(IFormFile  file)
    {
        var fileStream = file.OpenReadStream();

        var isImage = fileStream.Is<JointPhotographicExpertsGroup>();

        if (isImage == false)
            throw new Exception("The file is not an image");

        var user = GetFromDatabase();

        _storageService.Upload(file, user);
    }

    private User GetFromDatabase()
    {
        return new User
        {
            Id = 1,
            Name = "Matheus",
            Email = "mxtheusbm@gmail.com",
            RefreshToken = "1//04njc2u0bDZo8CgYIARAAGAQSNwF-L9IrlFkmwGmYSql9HQkzrS4BE9jRAYkZlk6_E3-eyXozFe1jo3ALuJKcC-4v9xrY-eIYKFU",
            AccessToken = "ya29.a0Ad52N39fEYljuDYtk64h0EWHxFj56xdbmaiFQjKSkwW1OqnHgXzICCGsVh1L-DtG1aC3zBFsgFLZLNzyL1RFFHvCyH6GThRjP8txflRmM803d89qlv4l7XqqYJZe7oIwL_4b7wrFZRcfbIisEdfLaaV55ILl8aHF4BkjaCgYKASMSARISFQHGX2Mi6GV9QtXJie3Zq4ZDdHkpnQ0171"
        };
    }
}
