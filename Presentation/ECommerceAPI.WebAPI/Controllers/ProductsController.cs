using Microsoft.AspNetCore.Mvc;
using System.Net;
using ECommerceAPI.Application.Const;
using ECommerceAPI.Application.CustomAttribute;
using ECommerceAPI.Application.Enums;
using ECommerceAPI.Application.Features.Commands.ProductCommands.CreateProduct;
using ECommerceAPI.Application.Features.Commands.ProductCommands.DeleteProduct;
using ECommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts;
using ECommerceAPI.Application.Features.Queries.ProductQueries.GetProductById;
using MediatR;
using ECommerceAPI.Application.Features.Commands.ProductCommands.UpdateProduct;
using ECommerceAPI.Application.Features.Commands.ProductImageCommands.ChangeShowcaseImage;
using ECommerceAPI.Application.Features.Commands.ProductImageCommands.DeleteProductImage;
using ECommerceAPI.Application.Features.Commands.ProductImageCommands.UploadProductImages;
using ECommerceAPI.Application.Features.Queries.ProductImageQueries.GetProductImages;
using ECommerceAPI.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IProductService _productService;
        public ProductsController(IMediator mediator, IProductService productService)
        {
            _mediator = mediator;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductsQueryRequest request)
        {
            GetAllProductsQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetProductByIdQueryRequest request)
        {
            GetProductByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Create Products")]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await _mediator.Send(request);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Update Product")]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response = await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommandRequest request)
        {
            DeleteProductCommandResponse response = await _mediator.Send(request);
            return Ok();
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Upload Product Image")]
        public async Task<IActionResult> UploadProductImage([FromQuery] UploadProductImagesCommandRequest request)
        {
            request.Files = Request.Form.Files;
            UploadProductImagesCommandResponse response = await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest request)
        {
            List<GetProductImagesQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        // id = product id, it called only id because of http client service in client side
        [HttpDelete("[action]/{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product Image")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] DeleteProductImageCommandRequest request)
        {
            //request.ImageId = imageId;
            DeleteProductImageCommandResponse response = await _mediator.Send(request);
            return Ok();
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Update Product Showcase Image")]
        public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowcaseImageCommandRequest request)
        {
            ChangeShowcaseImageCommandResponse response = await _mediator.Send(request);
            return Ok();
        }
        
        [HttpGet("qrcode/{productId}")]
        public async Task<IActionResult> GetQrCodeToProduct([FromRoute] Guid productId)
        {
            var data = await _productService.QrCodeToProductAsync(productId);
            return File(data, "image/png");
        }
    }
}
