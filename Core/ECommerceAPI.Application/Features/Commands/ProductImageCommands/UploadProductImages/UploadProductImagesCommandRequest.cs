using MediatR;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Application.Features.Commands.ProductImageCommands.UploadProductImages;

public class UploadProductImagesCommandRequest : IRequest<UploadProductImagesCommandResponse>
{
    public Guid Id { get; set; }
    public IFormFileCollection? Files { get; set; }
}