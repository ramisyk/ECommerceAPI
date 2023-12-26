using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAPI.Application.Services.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationServicesController : ControllerBase
    {
        private IApplicationServices _applicationServices;

        public ApplicationServicesController(IApplicationServices applicationServices)
        {
            _applicationServices = applicationServices;
        }

        public IActionResult GetAuthorizeDefinitionEndpoint()
        {
            var data = _applicationServices.GetAuthorizeDefinitionEndpoints(typeof(Program));
            return Ok(data);
        }
    }
}
