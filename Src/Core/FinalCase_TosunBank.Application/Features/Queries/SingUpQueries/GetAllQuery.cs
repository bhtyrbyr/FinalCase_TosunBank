using AutoMapper;
using FinalCase_TosunBank.Application.DTOs.SingupDTOs;
using FinalCase_TosunBank.Application.Repository;
using MediatR;

namespace FinalCase_TosunBank.Application.Features.Queries.SingUpQueries;

public class GetAllQuery : IRequest<List<SignUpViewDTO>>
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<SignUpViewDTO>>
    {
        private readonly INewCustomerAccountOpeningRequestRepository _preRegistrationRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(INewCustomerAccountOpeningRequestRepository preRegistrationRepository, IMapper mapper)
        {
            _preRegistrationRepository = preRegistrationRepository;
            _mapper = mapper;
        }

        public async Task<List<SignUpViewDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var list = await _preRegistrationRepository.GetAllAsync();
            var result = _mapper.Map<List<SignUpViewDTO>>(list);
            return result;
        }
    }
}
