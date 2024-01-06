using FinalCase_TosunBank.Domain.Entities;
using FinalCase_TosunBank.WebApi.TokenOperations;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Queries.GetTokenQuery;

public class GetTokenQuery : IRequest<string>
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, string>
    {
        private readonly IAuthService _authService;

        public GetTokenQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<string> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            var result = await _authService.Login("bhtyrbyr", "Qawsedb12*");
            return result.Message;
        }
    }
}
