using FinalCase_TosunBank.Application.Features.Queries.Temp;
using FinalCase_TosunBank.Application.Repository;
using FinalCase_TosunBank.Domain.Common;
using FinalCase_TosunBank.Domain.Entities;
using FinalCase_TosunBank.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalCase_TosunBank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<BasePerson> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IDepartmentRepository _departmentRepo;

        public TempController(IMediator mediator, IDepartmentRepository departmentRepo, UserManager<BasePerson> userManager, RoleManager<IdentityRole> roleManager)
        {
            _mediator = mediator;
            _userManager = userManager;
            _departmentRepo = departmentRepo;
            _roleManager = roleManager;
        }

        [HttpGet("{RoleName}", Name = "GetRoleToken")]
        public async Task<IActionResult> GetAdminToken(string RoleName)
        {
            var query = new TempGetTokenQuery(RoleName);
            var token = await _mediator.Send(query);
            if (token is not null) return Ok(token);
            else return BadRequest(RoleName + " not found!");
        }

        [HttpGet("SetRecords")]
        [Authorize(Roles = "unreachable")]
        public async Task<IActionResult> SetRecords()
        {
            //Departman kaydı oluşturma
            var department = new Department() { Name = "Müşteri Hizmetleri" };
            _departmentRepo.CreateAsync(department);
            // Personel ve rol kayıtlarının eklenmesi
            var CustomerRole = new IdentityRole("Customer");
            var PersonnelRole = new IdentityRole("CustomerActionsPersonnel");
            var DirectorRole = new IdentityRole("Director");
            var AdminRole = new IdentityRole("Admin");
            await _roleManager.CreateAsync(CustomerRole);
            await _roleManager.CreateAsync(PersonnelRole);
            await _roleManager.CreateAsync(DirectorRole);
            await _roleManager.CreateAsync(AdminRole);
            var personel = new Authorised()
            {
                FirstName = "Müşteri",
                LastName = "Temsilcisi1",
                UserName = "mtemsilci1",
                Address = "Turkey",
                BirthDay = new DateTime(1990, 01, 01),
                Email = "mt1@tosunbank.com",
                SecurityCode = "mt1@1234",
                PhoneNumber = "1234567890",
                NationalityNumber = "11111111111"
            };
            await _userManager.CreateAsync(personel, "Qawsedb12*");
            await _userManager.AddToRoleAsync(personel, PersonnelRole.Name);
            department.Authoriseds.Add(personel);
            _departmentRepo.UpdateAsync(department);
            var director = new Authorised()
            {
                FirstName = "Müdür",
                LastName = "1",
                UserName = "mudur1",
                Address = "Turkey",
                BirthDay = new DateTime(1990, 01, 01),
                Email = "md1@tosunbank.com",
                SecurityCode = "md1@1234",
                PhoneNumber = "1234567890",
                NationalityNumber = "22222222222"
            };
            await _userManager.CreateAsync(director, "Qawsedb12*");
            await _userManager.AddToRoleAsync(director, DirectorRole.Name);
            department.Authoriseds.Add(director);
            _departmentRepo.UpdateAsync(department);
            var admin = new Authorised()
            {
                FirstName = "Yönetici",
                LastName = "1",
                UserName = "yonetici1",
                Address = "Turkey",
                BirthDay = new DateTime(1990, 01, 01),
                Email = "ynt1@tosunbank.com",
                SecurityCode = "ynt1@1234",
                PhoneNumber = "1234567890",
                NationalityNumber = "33333333333"
            };
            await _userManager.CreateAsync(admin, "Qawsedb12*");
            await _userManager.AddToRoleAsync(admin, AdminRole.Name);
            department.Authoriseds.Add(admin);
            _departmentRepo.UpdateAsync(department);

            // Müşteri kaydı eklenmesi
            var customer = new Customer()
            {
                FirstName = "Müşteri",
                LastName = "1",
                UserName = "0000000001",
                Address = "Turkey",
                BirthDay = new DateTime(1990, 01, 01),
                Email = "mst1@tosunbank.com",
                SecurityCode = "mst1@1234",
                PhoneNumber = "1234567890",
                AccountOppeningApproval = personel,
                AccountOppeningApprovalId = personel.Id,
                CreditScore = 100,
                Salary = 25120.05,
                SalaryCustomer = true,
                NationalityNumber = "44444444444"
            };
            await _userManager.CreateAsync(customer, "Qawsedb12*");
            await _userManager.AddToRoleAsync(customer, CustomerRole.Name);

            string result = string.Format($"Personel Id= {personel.Id}\r\n" +
                                          $"Director Id= {director.Id}\r\n" +
                                          $"Admin    Id= {admin.Id}\r\n" +
                                          $"Customer Id= {customer.Id}\r\n");
            return Ok(result);
        }
    }
}
