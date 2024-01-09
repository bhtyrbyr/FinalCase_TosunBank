using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Entities;
using MediatR;

namespace FinalCase_TosunBank.Application.Features.Queries.AccountQueries;

public class GetNewAccountOpeningRequestByIdQuery : IRequest<AccountOpeningRequest>
{
    private readonly int Id;

    public GetNewAccountOpeningRequestByIdQuery(int id) => Id = id;

    public class GetNewAccountOpeningRequestByIdQueryHandler : IRequestHandler<GetNewAccountOpeningRequestByIdQuery, AccountOpeningRequest>
    {
        private readonly IAccountOpeningRequestRepository _accountOpeningRequestRepo;

        public GetNewAccountOpeningRequestByIdQueryHandler(IAccountOpeningRequestRepository accountOpeningRequestRepo)
        {
            _accountOpeningRequestRepo = accountOpeningRequestRepo;
        }

        public async Task<AccountOpeningRequest> Handle(GetNewAccountOpeningRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _accountOpeningRequestRepo.GetByIdAsync(request.Id);
            return result;
        }
    }
}
