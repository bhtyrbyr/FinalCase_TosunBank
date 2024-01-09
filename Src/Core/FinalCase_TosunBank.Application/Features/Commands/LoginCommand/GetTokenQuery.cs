using FinalCase_TosunBank.Application.DTOs.LoginDTO;
using FinalCase_TosunBank.WebApi.TokenOperations;
using MediatR;

namespace FinalCase_TosunBank.Application.Features.Commands.LoginCommand;

public class GetTokenQuery : IRequest<string>
{
    private readonly BasePersonLoginDTO Model;
    public GetTokenQuery(BasePersonLoginDTO model)
    {
        Model = model;
    }
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, string>
    {
        private readonly IAuthService _service;

        public GetTokenQueryHandler(IAuthService service)
        {
            _service = service;
        }

        public async Task<string> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            var token = await _service.Login(request.Model.UserName, request.Model.Password);
            return token.Message;
        }
    }
}
