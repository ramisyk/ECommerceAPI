﻿using ECommerceAPI.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Infrastructure.Services.Storage;

public class StorageService : IStorageService
{
    private readonly IStorage _storage;

    public StorageService(IStorage storage)
    {
        _storage = storage;
    }

    public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
    {
        return await _storage.UploadAsync(pathOrContainerName, files);
    }

    public async Task DeleteAsync(string pathOrContainerName, string fileName)
    {
        await _storage.DeleteAsync(pathOrContainerName, fileName);
    }
    
    public List<string> GetFiles(string pathOrContainerName)
    {
        return _storage.GetFiles(pathOrContainerName);
    }

    public bool HasFile(string pathOrContainerName, string fileName)
    {
        return _storage.HasFile(pathOrContainerName, fileName);
    }

    public string StorageName
    {
        get => _storage.GetType().Name;
    }
}