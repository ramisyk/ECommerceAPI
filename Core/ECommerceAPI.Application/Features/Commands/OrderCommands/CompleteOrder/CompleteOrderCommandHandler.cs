using ECommerceAPI.Application.Services;
using ECommerceAPI.Application.ViewModels.Orders;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.OrderCommands.CompleteOrder;

public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommandRequest, CompleteOrderCommandResponse>
{
    private readonly IOrderService _orderService;
    private readonly IMailService _mailService;
    public CompleteOrderCommandHandler(IOrderService orderService, IMailService mailService)
    {
        _orderService = orderService;
        _mailService = mailService;
    }

    public async Task<CompleteOrderCommandResponse> Handle(CompleteOrderCommandRequest request, CancellationToken cancellationToken)
    {
        (bool succeeded, VM_Completed_Order completedOrder) = await _orderService.CompleteOrderAsync(request.Id);
        if (succeeded)
            await _mailService.SendCompletedOrderMailAsync(completedOrder.EMail, completedOrder.OrderCode, completedOrder.OrderDate, completedOrder.Username);
        return new();
    }
}