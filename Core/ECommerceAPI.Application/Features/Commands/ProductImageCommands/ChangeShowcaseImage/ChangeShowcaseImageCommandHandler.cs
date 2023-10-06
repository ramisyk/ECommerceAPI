﻿using ECommerceAPI.Application.Repositories.ProductImageFileRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Application.Features.Commands.ProductImageCommands.ChangeShowcaseImage;

public class ChangeShowcaseImageCommandHandler : IRequestHandler<ChangeShowcaseImageCommandRequest, ChangeShowcaseImageCommandResponse>
{
    private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

    public ChangeShowcaseImageCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepository)
    {
        _productImageFileWriteRepository = productImageFileWriteRepository;
    }

    public async Task<ChangeShowcaseImageCommandResponse> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
    {
        var query = _productImageFileWriteRepository.Table
            .Include(p => p.Products)
            .SelectMany(p => p.Products, (pif, p) => new
            {
                pif,
                p
            });
        
        var data = await query.FirstOrDefaultAsync(p => p.p.Id == request.ProductId && p.pif.Showcase);
        if (data != null)
            data.pif.Showcase = false;
        
        var image = await query.FirstOrDefaultAsync(p => p.pif.Id == request.ImageId);
        if (image != null)
            image.pif.Showcase = true;

        await _productImageFileWriteRepository.SaveAsync();
        
        return new ChangeShowcaseImageCommandResponse();
    }
}