using Asp.Versioning;
using AutoMapper;
using NewTemplateManager.Api.Mapping;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace NewTemplateManager.Api.Controllers
{
    // [Route("api/[controller]")]
    // [ApiVersion("2.0")]
    [ApiController]
    // public class DVBaseController<T> : ControllerBase where T : DVBaseController<T>

    public abstract class TheBaseController<T> : ControllerBase where T : TheBaseController<T>
    {
        protected ILogger<T> _logger;
        protected ISender _sender;

        public TheBaseController(ILogger<T> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
            //_mapper = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<MappingProfile>();
            //}).CreateMapper();
        }
    }
}
