using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAPI.Application.Features.Commands.OrderCommands.CreateOrder;
using ECommerceAPI.Application.Features.Queries.OrderQueries.GetAllOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllOrders([FromQuery] GetAllOrdersQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok();
        }
    }
}