using FinalCase_TosunBank.Application.DTOs.AuthoriseDTO;
using FinalCase_TosunBank.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Commands.AuthorisationCommands;

public class AuthorisedCommand : IRequest<bool>
{
    private readonly AuthorisationArrangementDTO Model;
    
    public AuthorisedCommand(AuthorisationArrangementDTO model)
    {
        Model = model;
    }

    public class AuthorisedCommandHandler : IRequestHandler<AuthorisedCommand, bool>
    {
        private readonly UserManager<BasePerson> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthorisedCommandHandler(UserManager<BasePerson> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> Handle(AuthorisedCommand request, CancellationToken cancellationToken)
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
            var result = await _userManager.AddToRoleAsync(person, role.Name);
            return result.Succeeded;
        }
    }
}
