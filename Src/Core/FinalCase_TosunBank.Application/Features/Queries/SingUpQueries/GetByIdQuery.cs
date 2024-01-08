using AutoMapper;
using FinalCase_TosunBank.Application.DTOs.SingupDTOs;
using FinalCase_TosunBank.Application.Repository;
using MediatR;

namespace FinalCase_TosunBank.Application.Features.Queries.SingUpQueries;

public class GetByIdQuery : IRequest<SignUpViewDTO>
{
    private readonly int Id;
    public GetByIdQuery(int id) => Id = id;

    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, SignUpViewDTO>
    {
        private readonly IPreRegistrationRepository _preRegistrationRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IPreRegistrationRepository preRegistrationRepository, IMapper mapper)
        {
            _preRegistrationRepository = preRegistrationRepository;
            _mapper = mapper;
        }
        public async Task<SignUpViewDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var record = await _preRegistrationRepository.GetByIdAsync(request.Id);
            if(record is null) throw new ArgumentNullException(nameof(record));
            var result = _mapper.Map<SignUpViewDTO>(record);
            return result;
        }
    }
}
