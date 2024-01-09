using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Entities;
using MediatR;

namespace FinalCase_TosunBank.Application.Features.Queries.AccountQueries;

public class GetNewBankAccountOpeningRequestGetByIdQuery : IRequest<NewBankAccountOpeningRequest>
{
    private readonly int Id;

    public GetNewBankAccountOpeningRequestGetByIdQuery(int id) => Id = id;

    public class GetNewBankAccountOpeningRequestGetByIdQueryHandler : IRequestHandler<GetNewBankAccountOpeningRequestGetByIdQuery, NewBankAccountOpeningRequest>
    {
        private readonly INewBankAccountOpeningRequestRepository _accountOpeningRequestRepo;

        public GetNewBankAccountOpeningRequestGetByIdQueryHandler(INewBankAccountOpeningRequestRepository accountOpeningRequestRepo)
        {
            _accountOpeningRequestRepo = accountOpeningRequestRepo;
        }

        public async Task<NewBankAccountOpeningRequest> Handle(GetNewBankAccountOpeningRequestGetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _accountOpeningRequestRepo.GetByIdAsync(request.Id);
            return result;
        }
    }
}
