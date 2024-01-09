using AutoMapper;
using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Queries.AccountQueries;

public class GetNewBankAccountOpeningRequestGetAllQuery : IRequest<List<NewBankAccountOpeningRequest>>
{
    public class GetNewBankAccountOpeningRequestGetAllQueryHandler : IRequestHandler<GetNewBankAccountOpeningRequestGetAllQuery, List<NewBankAccountOpeningRequest>>
    {
        private readonly INewBankAccountOpeningRequestRepository _accountOpeningRequestRepo;

        public GetNewBankAccountOpeningRequestGetAllQueryHandler(INewBankAccountOpeningRequestRepository accountOpeningRequestRepo)
        {
            _accountOpeningRequestRepo = accountOpeningRequestRepo;
        }

        public async Task<List<NewBankAccountOpeningRequest>> Handle(GetNewBankAccountOpeningRequestGetAllQuery request, CancellationToken cancellationToken)
        {
            var result = await _accountOpeningRequestRepo.GetAllAsync();
            return result;
        }
    }
}
