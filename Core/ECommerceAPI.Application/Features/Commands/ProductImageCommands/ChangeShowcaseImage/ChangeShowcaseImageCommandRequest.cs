using MediatR;

namespace ECommerceAPI.Application.Features.Commands.ProductImageCommands.ChangeShowcaseImage;

public class ChangeShowcaseImageCommandRequest : IRequest<ChangeShowcaseImageCommandResponse>
{
    public Guid ImageId { get; set; }
    public Guid ProductId { get; set; }
}