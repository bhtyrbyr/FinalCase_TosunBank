using AutoMapper;
using FinalCase_TosunBank.Application.DTOs.SingupDTOs;
using FinalCase_TosunBank.Application.Repository;
using MediatR;

namespace FinalCase_TosunBank.Application.Features.Queries.SingUpQueries;

public class GetAllQuery : IRequest<List<SingupViewDTO>>
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<SingupViewDTO>>
    {
        private readonly IPreRegistrationRepository _preRegistrationRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IPreRegistrationRepository preRegistrationRepository, IMapper mapper)
        {
            _preRegistrationRepository = preRegistrationRepository;
            _mapper = mapper;
        }

        public async Task<List<SingupViewDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var list = await _preRegistrationRepository.GetAllAsync();
            var result = _mapper.Map<List<SingupViewDTO>>(list);
            return result;
        }
    }
}
