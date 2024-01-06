using AutoMapper;
using FinalCase_TosunBank.Application.DTOs.CustomerDTOs;
using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using FinalCase_TosunBank.Domain.Entities;
using System.Text.RegularExpressions;

namespace FinalCase_TosunBank.Application.Features.Commands.CustomerCommands;

public class CreateCustomer : IRequest<string>
{
    public CreateDTO Model { get; set; }

    public CreateCustomer(CreateDTO model)
    {
        Model = model;
    }

    public class CreateCustomerHandler : IRequestHandler<CreateCustomer, string>
    {
        private readonly UserManager<BasePerson> _userManager;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _Mapper;

        public CreateCustomerHandler(UserManager<BasePerson> userManager, ICustomerRepository customerRepo, IMapper mapper)
        {
            _userManager = userManager;
            _customerRepo = customerRepo;
            _Mapper = mapper;
        }

        public async Task<string> Handle(CreateCustomer request, CancellationToken cancellationToken)
        {
            var query = await _userManager.FindByEmailAsync(request.Model.Email);
            if (query is not null)
                throw new ArgumentException(query.UserName + " already existed.");
            var newCustomer = FillingInTheRequiredInformation(_Mapper.Map<Customer>(request.Model));
            var result = await _userManager.CreateAsync(newCustomer, request.Model.Password);
            return newCustomer.Id;
        }

        private Customer FillingInTheRequiredInformation(Customer customer)
        {
            var input = Guid.NewGuid().ToString().Substring(0, 10);
            customer.SecurityCode = new Guid().ToString().Substring(0, 10);
            customer.SalaryCustomer = false;
            customer.CreditScore = 50;
            customer.AccountCreateDate = DateTime.Now; 
            customer.UserName = string.Join("", Regex.Matches(input, @"\d").Cast<Match>().Select(match => match.Value));
            return customer;
        }
    }
}