using FinalCase_TosunBank.Application.DTOs.AuthoriseDTO;
using FinalCase_TosunBank.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Commands.AuthorisationCommands;

public class UnauthorisedCommand : IRequest<bool>
{
    private readonly AuthorisationArrangementDTO Model;

    public UnauthorisedCommand(AuthorisationArrangementDTO model)
    {
        Model = model;
    }

    public class UnauthorisedCommandHandler : IRequestHandler<UnauthorisedCommand, bool>
    {
        private readonly UserManager<BasePerson> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UnauthorisedCommandHandler(UserManager<BasePerson> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> Handle(UnauthorisedCommand request, CancellationToken cancellationToken)
        {
            var authorised = await _userManager.FindByIdAsync(request.Model.AuthorisedId);
            if (authorised is null)
                throw new ArgumentNullException("No authorised record found!");
            var person = await _userManager.FindByIdAsync(request.Model.RecordId);
            if (person is null)
                throw new ArgumentNullException("No record found!");
            var role = await _roleManager.FindByNameAsync(request.Model.RoleName);
            if (role is null)
                throw new ArgumentNullException("No role record found!");
            var roles = await _userManager.GetRolesAsync(person);
            if (!roles.Any(hasRole => hasRole == role.Name))
                throw new ArgumentException("Person "+ role.Name + " has no role!");
            var result = await _userManager.RemoveFromRoleAsync(person, role.Name);
            return result.Succeeded;
        }
    }
}
