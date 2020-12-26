using Services.Models;
using Services.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Cars.Commands
{
    public class CreateCarCommand : IRequestWrapper<Car> { }

    public class CreateCarCommandHandler : IHandlerWrapper<CreateCarCommand, Car>
    {
        public Task<Response<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            if (false)
            {
                return Task.FromResult(Response.Fail<Car>("Car already exists"));
            }

            return Task.FromResult(Response.Success(new Car { Name = "Ford" }, "Car created."));
        }
    }

}