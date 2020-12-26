using MediatR;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Cars.Queries
{
    public class GetAllCarsQuery : BaseRequest, IRequest<IEnumerable<Car>>
    {

    }

    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<Car>>
    {
        public GetAllCarsQueryHandler()
        {
            // Do dependency injection here
        }

        public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            // some logic here
            return new []
            {
                new Car {Name = $"BMW {request.UserId}"},
                new Car {Name = "Citroen"},
                new Car {Name = "Mercedes"},
            };
        }
    }
}