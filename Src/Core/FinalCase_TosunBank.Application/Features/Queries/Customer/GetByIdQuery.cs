using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Entities;
using MediatR;

namespace FinalCase_TosunBank.Application.Features.Queries;

public class GetByIdQuery : IRequest<Customer>
{
    public string Id { get; set; }

    public GetByIdQuery(string id) => Id = id;

    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Customer>
    {
        private readonly ICustomerRepository _repo;

        public GetByIdQueryHandler(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task<Customer> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Get(request.Id);
        }
    }
}
