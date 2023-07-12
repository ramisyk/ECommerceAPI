using ECommerceAPI.Application.Abstractions.Storage.LocalStorage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ECommerceAPI.Infrastructure.Services.Storage.LocalStorage;

public class LocalStorage : ILocalStorage
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public LocalStorage(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    async Task<bool> CopyFileAsync(string path, IFormFile file)
    {
        try
        {
            await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            return true;
        }
        catch (Exception ex)
        {
            //todo log!
            throw ex;
        }
    }

    public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
    {
        string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        List<(string fileName, string path)> allData = new();
        foreach (IFormFile file in files)
        {
            await CopyFileAsync($"{uploadPath}\\{file.Name}", file);
            allData.Add((file.Name, $"{path}\\{file.Name}"));
        }

        return allData;
    }

    public async Task DeleteAsync(string path, string fileName)
    {
        File.Delete($"{path}\\{fileName}");
    }

    public List<string> GetFiles(string path)
    {
        DirectoryInfo directory = new(path);
        return directory.GetFiles().Select(f => f.Name).ToList();
    }

    public bool HasFile(string path, string fileName)
    {
        return File.Exists($"{path}\\{fileName}");
    }
}