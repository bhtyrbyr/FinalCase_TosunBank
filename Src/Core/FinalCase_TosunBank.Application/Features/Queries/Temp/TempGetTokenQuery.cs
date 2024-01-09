using FinalCase_TosunBank.WebApi.TokenOperations;
using MediatR;

namespace FinalCase_TosunBank.Application.Features.Queries.Temp;

public class TempGetTokenQuery : IRequest<string>
{
    private readonly string RoleName;
    public TempGetTokenQuery(string roleName)
    {
        RoleName = roleName;
    }
    public class GetTokenQueryHandler : IRequestHandler<TempGetTokenQuery, string>
    {
        private readonly IAuthService _service;

        public GetTokenQueryHandler(IAuthService service)
        {
            _service = service;
        }

        public async Task<string> Handle(TempGetTokenQuery request, CancellationToken cancellationToken)
        {
            switch (request.RoleName)
            {
                case "CustomerActionsPersonnel": return _service.Login("mtemsilci1", "Qawsedb12*").Result.Message;
                case "Director": return _service.Login("mudur1", "Qawsedb12*").Result.Message;
                case "Admin": return _service.Login("yonetici1", "Qawsedb12*").Result.Message;
                case "Customer": return _service.Login("0000000001", "Qawsedb12*").Result.Message;
                default: return null;
            }
        }
    }
}
