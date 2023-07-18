using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Repositories.ProductImageFileRepository;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.FileEntities;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.ProductImageCommands.UploadProductImages;

public class UploadProductImagesCommandHandler : IRequestHandler<UploadProductImagesCommandRequest, UploadProductImagesCommandResponse>
{
    private readonly IStorageService _storageService;
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

    public UploadProductImagesCommandHandler(IStorageService storageService, IProductReadRepository productReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository)
    {
        _storageService = storageService;
        _productReadRepository = productReadRepository;
        _productImageFileWriteRepository = productImageFileWriteRepository;
    }

    public async Task<UploadProductImagesCommandResponse> Handle(UploadProductImagesCommandRequest request, CancellationToken cancellationToken)
    {
        List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);

        Product product = await _productReadRepository.GetByIdAsync(request.Id);

        await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new ProductImageFile
        {
            FileName = r.fileName,
            Path = r.pathOrContainerName,
            Storage = _storageService.StorageName,
            Products = new List<Domain.Entities.Product>() { product }
        }).ToList());

        await _productImageFileWriteRepository.SaveAsync();

        return new();
    }
}