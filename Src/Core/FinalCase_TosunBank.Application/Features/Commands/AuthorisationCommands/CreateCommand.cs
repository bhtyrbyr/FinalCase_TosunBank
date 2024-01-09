using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Commands.AuthorisationCommands;

public class CreateCommand : IRequest<bool>
{
    private readonly string RoleName;

    public CreateCommand(string roleName)
    {
        RoleName = roleName;
    }

    public class CreateCommandHandler : IRequestHandler<CreateCommand, bool>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if (role is not null)
                throw new ArgumentException("Already exists!");
            var result = await _roleManager.CreateAsync(new IdentityRole(request.RoleName));
            return result.Succeeded;
        }
    }
}
