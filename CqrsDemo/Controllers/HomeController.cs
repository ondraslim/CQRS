using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Cars.Commands;
using Services.Cars.Queries;
using Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CqrsDemo.Controllers
{
    [ApiController]
    [Route("Cars")]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public Task<IEnumerable<Car>> Index(/*[FromBody] GetAllCarsQuery query*/)
        {
            return mediator.Send(new GetAllCarsQuery());
        }

        [HttpPost]
        public Task<Response<Car>> CreateCar([FromBody] CreateCarCommand command)
        {
            return mediator.Send(command);
        }
    }
}
