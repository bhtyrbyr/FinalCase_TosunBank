﻿using AutoMapper;
using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinalCase_TosunBank.Application.Features.Commands.SignUpCommands.Confirmation;

public class ConfirmationCommand : IRequest<string>
{
    private readonly int Id;
    private readonly string ApprovalId;

    public ConfirmationCommand(int id, string approvalId)
    {
        Id = id;
        ApprovalId = approvalId;
    }

    public class ConfirmationCommandHander : IRequestHandler<ConfirmationCommand, string>
    {
        private readonly IPreRegistrationRepository _preRegistrationRepository;
        private readonly UserManager<BasePerson> _userManager;
        private readonly IMapper _mapper;

        public ConfirmationCommandHander(IPreRegistrationRepository preRegistrationRepository, UserManager<BasePerson> userManager, IMapper mapper)
        {
            _preRegistrationRepository = preRegistrationRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<string> Handle(ConfirmationCommand request, CancellationToken cancellationToken)
        {
            var userInPreRegister = await _preRegistrationRepository.GetByIdAsync(request.Id);
            if((userInPreRegister is null) || (userInPreRegister.isConfirmed))
                throw new ArgumentNullException("No record found!");
            var AccountOppeningApproval = await _userManager.FindByIdAsync(request.ApprovalId) as Authorised;
            var newCustomer = _mapper.Map<Customer>(userInPreRegister);
            newCustomer.AccountOppeningApproval = AccountOppeningApproval;
            newCustomer.AccountOppeningApprovalId = request.ApprovalId;
            try
            {
                var registerStatus = await _userManager.CreateAsync(newCustomer, userInPreRegister.Password);
                await _userManager.AddToRoleAsync(newCustomer, "Customer");
                if (!registerStatus.Succeeded)
                    throw new ArgumentException("Error adding a record!");
                userInPreRegister.isConfirmed = true;
                //await _preRegistrationRepository.UpdateAsync(userInPreRegister);
                await _preRegistrationRepository.DeleteAsync(request.Id);
                return newCustomer.Id;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
